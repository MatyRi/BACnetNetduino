using System;
using System.Net;
using BACnetDataTypes;
using BACnetDataTypes.Constructed;
using BACnetDataTypes.Enumerated;
using BACnetDataTypes.Error;
using BACnetDataTypes.Exception;
using BACnetDataTypes.Primitive;
using BACnetNetwork;
using BACnetNetwork.NPDU;
using BACnetServices.APDU;
using BACnetServices.Service.Unconfirmed;
using Microsoft.SPOT;

namespace BACnetServices
{
    public class ApplicationLayer
    {
        private readonly NetworkLayer network;

        public NetworkLayer NetworkLayer => network;

        public ApplicationLayer(NetworkLayer network)
        {
            this.network = network;
            this.network.NewNPDUReceived += OnNPDUReceived;
        }

        public delegate void UnconfirmedRequestHandler(Address fromAddress, OctetString linkService, UnconfirmedRequest request);
        public event UnconfirmedRequestHandler UnconfirmedRequestReceived;

        public delegate void ConfirmedRequestHandler(Address fromAddress, OctetString linkService, int invokeId, ConfirmedRequest request);
        public event ConfirmedRequestHandler ConfirmedRequestReceived;

        private void OnNPDUReceived(IPEndPoint from, Address fromAddress, OctetString linkService, NPDU npdu, ByteStream raw)
        {
            try
            {

                APDU.APDU apdu = APDU.APDU.Parse(raw);

                incomingApdu(apdu, fromAddress, linkService);

                // TODO return APDU.createAPDU(servicesSupported, queue);
            }
            catch (System.Exception e)
            {
                // If it's already a BACnetException, don't bother wrapping it.
                //throw e;
                Debug.Print(e.Message);
                Debug.Print(e.StackTrace);
            }

            /*if (inBuffer.Length > 20)
                {
                    string result = printRouterInfo(inBuffer);
                    Debug.Print("Sending> " + result);

                    using (
                        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                            ProtocolType.Udp))
                    {
                        //EndPoint remoteEP = new IPEndPoint(IPAddress.Parse("192.168.0.14"), 55056);
                        byte[] messageBytes = Encoding.UTF8.GetBytes(result);
                        clientSocket.SendTo(messageBytes, remoteEndPoint);
                    }

                }
                else
                {
                    string message = new string(Encoding.UTF8.GetChars(inBuffer));
                    Debug.Print("Received> " + message);
                }*/
        }

        private void incomingApdu(APDU.APDU apdu, Address address, OctetString linkService)
        {
            // if (apdu.expectsReply() != npci.isExpectingReply())
            // throw new MessageValidationAssertionException("Inconsistent message: APDU expectsReply="+
            // apdu.expectsReply() +" while NPCI isExpectingReply="+ npci.isExpectingReply());

            if (apdu is ConfirmedRequest)
            {
                ConfirmedRequest confAPDU = (ConfirmedRequest) apdu;
                byte invokeId = confAPDU.getInvokeId();

                if (confAPDU.isSegmentedMessage() && confAPDU.getSequenceNumber() > 0)
                {
                    // This is a subsequent part of a segmented message. Notify the waiting room.
                    // TODO waitingRoom.notifyMember(address, linkService, invokeId, false, confAPDU);
                }
                else
                {
                    if (confAPDU.isSegmentedMessage())
                    {
                        // This is the initial part of a segmented message. Go and receive the subsequent parts.
                        /*WaitingRoomKey key = waitingRoom.enterServer(address, linkService, invokeId);
                    try
                    {
                        receiveSegmented(key, confAPDU);
                    }
                    finally
                    {
                        waitingRoom.leave(key);
                    }*/
                    }

                    // Handle the request.
                    try
                    {
                        confAPDU.parseServiceData();

                        /*if (localDevice.getDCCEnableDisable().equals(EnableDisable.disable))
                    {
                        // zpracovavame jenom reset a DCC
                        // povoleni probiha v handleru DCC
                        if (!(confAPDU.getServiceRequest() is DeviceCommunicationControlRequest ||
                        confAPDU.getServiceRequest() is ReinitializeDeviceRequest))
                        {
                            //throw new BACnetException("Communication blocked by DCC.");
                            return;
                        }
                    else
                        {
                            Debug.Print("DCC/Reinitialize received");
                        }
                    }*/


                        ConfirmedRequestReceived?.Invoke(address, linkService, invokeId, confAPDU); // EVENT


                        // TODO Move Handlers to LocalDevice
                    }
                    catch (BACnetErrorException e)
                    {
                        network.sendAPDU(address, linkService, new Error(invokeId, e.getError()), false);
                    }
                    catch (BACnetRejectException e)
                    {
                        network.sendAPDU(address, linkService, new Reject(invokeId, e.getRejectReason()), false);
                    }
                    catch (BACnetException e)
                    {
                        Error error = new Error(confAPDU.getInvokeId(),
                            new BaseError((byte) 127,
                                new BACnetError(ErrorClass.services, ErrorCode.inconsistentParameters)));
                        network.sendAPDU(address, linkService, error, false);
                        // TODO ExceptionDispatch.fireReceivedException(e);
                    }
                }
            }
            else if (apdu is UnconfirmedRequest)
            {
                //DCC - reakce na prichozi zpravy - blokujeme vsechny Unconfirmed
                /* TODO if (localDevice.getDCCEnableDisable().equals(EnableDisable.disable))
                {
                    return;
                }*/
                UnconfirmedRequestReceived?.Invoke(address, linkService, (UnconfirmedRequest) apdu);
            }
            else
            {
                // An acknowledgement.
                AckAPDU ack = (AckAPDU) apdu;

                // Used for testing only. This is required to test the parsing of service data in an ack.
                // ((ComplexACK) ack).parseServiceData();

                //waitingRoom.notifyMember(address, linkService, ack.getOriginalInvokeId(), ack.isServer(), ack);
            }
        }

        public LocalDevice Device { get; set; }

        public void sendUnconfirmed(Address address, OctetString linkService, UnconfirmedRequestService serviceRequest, bool broadcast) 
        {
            sendUnconfirmed(address, linkService, serviceRequest, broadcast, false);
        }

        public void sendUnconfirmed(Address address, OctetString linkService, UnconfirmedRequestService serviceRequest, bool broadcast, bool initiated)
        {
            if (address == null)
                throw new ArgumentException("address cannot be null");
            if (address.Equals(linkService))
                linkService = null;

            /*
            //DCC - neodesilat nic
            if (Device.getDCCEnableDisable().equals(EnableDisable.disable))
            {
                throw new BACnetException("Communication blocked by DCC.");
            }
            // Odesilat jenom I-Am, pokud bylo iniciovano
            if (Device.getDCCEnableDisable().equals(EnableDisable.disableInitiation) && !initiated)
            {
                throw new BACnetException("Communication blocked by DCC.");
            }
            */

            // Unconfirmed services will never have to be segmented, so just send it.
            network.sendAPDU(address, linkService, new UnconfirmedRequest(serviceRequest), broadcast);
        }
    }
}
