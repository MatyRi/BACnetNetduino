using System;
using Microsoft.SPOT;

namespace BACnetNetduino.DataTypes.Enumerated
{
    class VtClass : Primitive.Enumerated
    {
        public static readonly VtClass defaultTerminal = new VtClass(0);
        public static readonly VtClass ansi_x3_64 = new VtClass(1);
        public static readonly VtClass dec_vt52 = new VtClass(2);
        public static readonly VtClass dec_vt100 = new VtClass(3);
        public static readonly VtClass dec_vt220 = new VtClass(4);
        public static readonly VtClass hp_700_94 = new VtClass(5);
        public static readonly VtClass ibm_3130 = new VtClass(6);

        public static readonly VtClass[] ALL = { defaultTerminal, ansi_x3_64, dec_vt52, dec_vt100, dec_vt220, hp_700_94, ibm_3130, };

    public VtClass(uint value) : base(value) { }

    public VtClass(ByteStream queue) : base(queue) { }
}
}
