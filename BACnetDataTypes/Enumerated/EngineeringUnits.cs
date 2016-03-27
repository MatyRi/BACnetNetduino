namespace BACnetDataTypes.Enumerated
{
    class EngineeringUnits : Primitive.Enumerated
    {
        // Acceleration
        public static readonly EngineeringUnits MetersPerSecondPerSecond = new EngineeringUnits(166);
        // Area
        public static readonly EngineeringUnits SquareMeters = new EngineeringUnits(0);
        public static readonly EngineeringUnits SquareCentimeters = new EngineeringUnits(116);
        public static readonly EngineeringUnits SquareFeet = new EngineeringUnits(1);
        public static readonly EngineeringUnits SquareInches = new EngineeringUnits(115);
        // Currency
        public static readonly EngineeringUnits Currency1 = new EngineeringUnits(105);
        public static readonly EngineeringUnits Currency2 = new EngineeringUnits(106);
        public static readonly EngineeringUnits Currency3 = new EngineeringUnits(107);
        public static readonly EngineeringUnits Currency4 = new EngineeringUnits(108);
        public static readonly EngineeringUnits Currency5 = new EngineeringUnits(109);
        public static readonly EngineeringUnits Currency6 = new EngineeringUnits(110);
        public static readonly EngineeringUnits Currency7 = new EngineeringUnits(111);
        public static readonly EngineeringUnits Currency8 = new EngineeringUnits(112);
        public static readonly EngineeringUnits Currency9 = new EngineeringUnits(113);
        public static readonly EngineeringUnits Currency10 = new EngineeringUnits(114);
        // Electrical
        public static readonly EngineeringUnits Milliamperes = new EngineeringUnits(2);
        public static readonly EngineeringUnits Amperes = new EngineeringUnits(3);
        public static readonly EngineeringUnits AmperesPerMeter = new EngineeringUnits(167);
        public static readonly EngineeringUnits AmperesPerSquareMeter = new EngineeringUnits(168);
        public static readonly EngineeringUnits AmpereSquareMeters = new EngineeringUnits(169);
        public static readonly EngineeringUnits Farads = new EngineeringUnits(170);
        public static readonly EngineeringUnits Henrys = new EngineeringUnits(171);
        public static readonly EngineeringUnits Ohms = new EngineeringUnits(4);
        public static readonly EngineeringUnits OhmMeters = new EngineeringUnits(172);
        public static readonly EngineeringUnits Milliohms = new EngineeringUnits(145);
        public static readonly EngineeringUnits Kilohms = new EngineeringUnits(122);
        public static readonly EngineeringUnits Megohms = new EngineeringUnits(123);
        public static readonly EngineeringUnits Siemens = new EngineeringUnits(173); // 1 mho equals 1 siemens
        public static readonly EngineeringUnits SiemensPerMeter = new EngineeringUnits(174);
        public static readonly EngineeringUnits Teslas = new EngineeringUnits(175);
        public static readonly EngineeringUnits Volts = new EngineeringUnits(5);
        public static readonly EngineeringUnits Millivolts = new EngineeringUnits(124);
        public static readonly EngineeringUnits Kilovolts = new EngineeringUnits(6);
        public static readonly EngineeringUnits Megavolts = new EngineeringUnits(7);
        public static readonly EngineeringUnits VoltAmperes = new EngineeringUnits(8);
        public static readonly EngineeringUnits KilovoltAmperes = new EngineeringUnits(9);
        public static readonly EngineeringUnits MegavoltAmperes = new EngineeringUnits(10);
        public static readonly EngineeringUnits VoltAmperesReactive = new EngineeringUnits(11);
        public static readonly EngineeringUnits KilovoltAmperesReactive = new EngineeringUnits(12);
        public static readonly EngineeringUnits MegavoltAmperesReactive = new EngineeringUnits(13);
        public static readonly EngineeringUnits VoltsPerDegreeKelvin = new EngineeringUnits(176);
        public static readonly EngineeringUnits VoltsPerMeter = new EngineeringUnits(177);
        public static readonly EngineeringUnits DegreesPhase = new EngineeringUnits(14);
        public static readonly EngineeringUnits PowerFactor = new EngineeringUnits(15);
        public static readonly EngineeringUnits Webers = new EngineeringUnits(178);
        // Energy
        public static readonly EngineeringUnits Joules = new EngineeringUnits(16);
        public static readonly EngineeringUnits Kilojoules = new EngineeringUnits(17);
        public static readonly EngineeringUnits KilojoulesPerKilogram = new EngineeringUnits(125);
        public static readonly EngineeringUnits Megajoules = new EngineeringUnits(126);
        public static readonly EngineeringUnits WattHours = new EngineeringUnits(18);
        public static readonly EngineeringUnits KilowattHours = new EngineeringUnits(19);
        public static readonly EngineeringUnits MegawattHours = new EngineeringUnits(146);
        public static readonly EngineeringUnits Btus = new EngineeringUnits(20);
        public static readonly EngineeringUnits KiloBtus = new EngineeringUnits(147);
        public static readonly EngineeringUnits MegaBtus = new EngineeringUnits(148);
        public static readonly EngineeringUnits Therms = new EngineeringUnits(21);
        public static readonly EngineeringUnits TonHours = new EngineeringUnits(22);
        // Enthalpy
        public static readonly EngineeringUnits JoulesPerKilogramDryAir = new EngineeringUnits(23);
        public static readonly EngineeringUnits KilojoulesPerKilogramDryAir = new EngineeringUnits(149);
        public static readonly EngineeringUnits MegajoulesPerKilogramDryAir = new EngineeringUnits(150);
        public static readonly EngineeringUnits BtusPerPoundDryAir = new EngineeringUnits(24);
        public static readonly EngineeringUnits BtusPerPound = new EngineeringUnits(117);
        // Entropy
        public static readonly EngineeringUnits JoulesPerDegreeKelvin = new EngineeringUnits(127);
        public static readonly EngineeringUnits KilojoulesPerDegreeKelvin = new EngineeringUnits(151);
        public static readonly EngineeringUnits MegajoulesPerDegreeKelvin = new EngineeringUnits(152);
        public static readonly EngineeringUnits JoulesPerKilogramDegreeKelvin = new EngineeringUnits(128);
        // Force
        public static readonly EngineeringUnits Newton = new EngineeringUnits(153);
        // Frequency
        public static readonly EngineeringUnits CyclesPerHour = new EngineeringUnits(25);
        public static readonly EngineeringUnits CyclesPerMinute = new EngineeringUnits(26);
        public static readonly EngineeringUnits Hertz = new EngineeringUnits(27);
        public static readonly EngineeringUnits Kilohertz = new EngineeringUnits(129);
        public static readonly EngineeringUnits Megahertz = new EngineeringUnits(130);
        public static readonly EngineeringUnits PerHour = new EngineeringUnits(131);
        // Humidity
        public static readonly EngineeringUnits GramsOfWaterPerKilogramDryAir = new EngineeringUnits(28);
        public static readonly EngineeringUnits PercentRelativeHumidity = new EngineeringUnits(29);
        // Length
        public static readonly EngineeringUnits Millimeters = new EngineeringUnits(30);
        public static readonly EngineeringUnits Centimeters = new EngineeringUnits(118);
        public static readonly EngineeringUnits Meters = new EngineeringUnits(31);
        public static readonly EngineeringUnits Inches = new EngineeringUnits(32);
        public static readonly EngineeringUnits Feet = new EngineeringUnits(33);
        // Light
        public static readonly EngineeringUnits Candelas = new EngineeringUnits(179);
        public static readonly EngineeringUnits CandelasPerSquareMeter = new EngineeringUnits(180);
        public static readonly EngineeringUnits WattsPerSquareFoot = new EngineeringUnits(34);
        public static readonly EngineeringUnits WattsPerSquareMeter = new EngineeringUnits(35);
        public static readonly EngineeringUnits Lumens = new EngineeringUnits(36);
        public static readonly EngineeringUnits Luxes = new EngineeringUnits(37);
        public static readonly EngineeringUnits FootCandles = new EngineeringUnits(38);
        // Mass
        public static readonly EngineeringUnits Kilograms = new EngineeringUnits(39);
        public static readonly EngineeringUnits PoundsMass = new EngineeringUnits(40);
        public static readonly EngineeringUnits Tons = new EngineeringUnits(41);
        // Mass Flow
        public static readonly EngineeringUnits GramsPerSecond = new EngineeringUnits(154);
        public static readonly EngineeringUnits GramsPerMinute = new EngineeringUnits(155);
        public static readonly EngineeringUnits KilogramsPerSecond = new EngineeringUnits(42);
        public static readonly EngineeringUnits KilogramsPerMinute = new EngineeringUnits(43);
        public static readonly EngineeringUnits KilogramsPerHour = new EngineeringUnits(44);
        public static readonly EngineeringUnits PoundsMassPerSecond = new EngineeringUnits(119);
        public static readonly EngineeringUnits PoundsMassPerMinute = new EngineeringUnits(45);
        public static readonly EngineeringUnits PoundsMassPerHour = new EngineeringUnits(46);
        public static readonly EngineeringUnits TonsPerHour = new EngineeringUnits(156);
        // Power
        public static readonly EngineeringUnits Milliwatts = new EngineeringUnits(132);
        public static readonly EngineeringUnits Watts = new EngineeringUnits(47);
        public static readonly EngineeringUnits Kilowatts = new EngineeringUnits(48);
        public static readonly EngineeringUnits Megawatts = new EngineeringUnits(49);
        public static readonly EngineeringUnits BtusPerHour = new EngineeringUnits(50);
        public static readonly EngineeringUnits KiloBtusPerHour = new EngineeringUnits(157);
        public static readonly EngineeringUnits Horsepower = new EngineeringUnits(51);
        public static readonly EngineeringUnits TonsRefrigeration = new EngineeringUnits(52);
        // Pressure
        public static readonly EngineeringUnits Pascals = new EngineeringUnits(53);
        public static readonly EngineeringUnits Hectopascals = new EngineeringUnits(133);
        public static readonly EngineeringUnits Kilopascals = new EngineeringUnits(54);
        public static readonly EngineeringUnits Millibars = new EngineeringUnits(134);
        public static readonly EngineeringUnits Bars = new EngineeringUnits(55);
        public static readonly EngineeringUnits PoundsForcePerSquareInch = new EngineeringUnits(56);
        public static readonly EngineeringUnits CentimetersOfWater = new EngineeringUnits(57);
        public static readonly EngineeringUnits InchesOfWater = new EngineeringUnits(58);
        public static readonly EngineeringUnits MillimetersOfMercury = new EngineeringUnits(59);
        public static readonly EngineeringUnits CentimetersOfMercury = new EngineeringUnits(60);
        public static readonly EngineeringUnits InchesOfMercury = new EngineeringUnits(61);
        // Temperature
        public static readonly EngineeringUnits DegreesCelsius = new EngineeringUnits(62);
        public static readonly EngineeringUnits DegreesKelvin = new EngineeringUnits(63);
        public static readonly EngineeringUnits DegreesKelvinPerHour = new EngineeringUnits(181);
        public static readonly EngineeringUnits DegreesKelvinPerMinute = new EngineeringUnits(182);
        public static readonly EngineeringUnits DegreesFahrenheit = new EngineeringUnits(64);
        public static readonly EngineeringUnits DegreeDaysCelsius = new EngineeringUnits(65);
        public static readonly EngineeringUnits DegreeDaysFahrenheit = new EngineeringUnits(66);
        public static readonly EngineeringUnits DeltaDegreesFahrenheit = new EngineeringUnits(120);
        public static readonly EngineeringUnits DeltaDegreesKelvin = new EngineeringUnits(121);
        // Time
        public static readonly EngineeringUnits Years = new EngineeringUnits(67);
        public static readonly EngineeringUnits Months = new EngineeringUnits(68);
        public static readonly EngineeringUnits Weeks = new EngineeringUnits(69);
        public static readonly EngineeringUnits Days = new EngineeringUnits(70);
        public static readonly EngineeringUnits Hours = new EngineeringUnits(71);
        public static readonly EngineeringUnits Minutes = new EngineeringUnits(72);
        public static readonly EngineeringUnits Seconds = new EngineeringUnits(73);
        public static readonly EngineeringUnits HundredthsSeconds = new EngineeringUnits(158);
        public static readonly EngineeringUnits Milliseconds = new EngineeringUnits(159);
        // Torque
        public static readonly EngineeringUnits NewtonMeters = new EngineeringUnits(160);
        // Velocity
        public static readonly EngineeringUnits MillimetersPerSecond = new EngineeringUnits(161);
        public static readonly EngineeringUnits MillimetersPerMinute = new EngineeringUnits(162);
        public static readonly EngineeringUnits MetersPerSecond = new EngineeringUnits(74);
        public static readonly EngineeringUnits MetersPerMinute = new EngineeringUnits(163);
        public static readonly EngineeringUnits MetersPerHour = new EngineeringUnits(164);
        public static readonly EngineeringUnits KilometersPerHour = new EngineeringUnits(75);
        public static readonly EngineeringUnits FeetPerSecond = new EngineeringUnits(76);
        public static readonly EngineeringUnits FeetPerMinute = new EngineeringUnits(77);
        public static readonly EngineeringUnits MilesPerHour = new EngineeringUnits(78);
        // Volume
        public static readonly EngineeringUnits CubicFeet = new EngineeringUnits(79);
        public static readonly EngineeringUnits CubicMeters = new EngineeringUnits(80);
        public static readonly EngineeringUnits ImperialGallons = new EngineeringUnits(81);
        public static readonly EngineeringUnits Liters = new EngineeringUnits(82);
        public static readonly EngineeringUnits UsGallons = new EngineeringUnits(83);
        // Volumetric Flow
        public static readonly EngineeringUnits CubicFeetPerSecond = new EngineeringUnits(142);
        public static readonly EngineeringUnits CubicFeetPerMinute = new EngineeringUnits(84);
        public static readonly EngineeringUnits CubicMetersPerSecond = new EngineeringUnits(85);
        public static readonly EngineeringUnits CubicMetersPerMinute = new EngineeringUnits(165);
        public static readonly EngineeringUnits CubicMetersPerHour = new EngineeringUnits(135);
        public static readonly EngineeringUnits ImperialGallonsPerMinute = new EngineeringUnits(86);
        public static readonly EngineeringUnits LitersPerSecond = new EngineeringUnits(87);
        public static readonly EngineeringUnits LitersPerMinute = new EngineeringUnits(88);
        public static readonly EngineeringUnits LitersPerHour = new EngineeringUnits(136);
        public static readonly EngineeringUnits UsGallonsPerMinute = new EngineeringUnits(89);
        // Other
        public static readonly EngineeringUnits DegreesAngular = new EngineeringUnits(90);
        public static readonly EngineeringUnits DegreesCelsiusPerHour = new EngineeringUnits(91);
        public static readonly EngineeringUnits DegreesCelsiusPerMinute = new EngineeringUnits(92);
        public static readonly EngineeringUnits DegreesFahrenheitPerHour = new EngineeringUnits(93);
        public static readonly EngineeringUnits DegreesFahrenheitPerMinute = new EngineeringUnits(94);
        public static readonly EngineeringUnits JouleSeconds = new EngineeringUnits(183);
        public static readonly EngineeringUnits KilogramsPerCubicMeter = new EngineeringUnits(186);
        public static readonly EngineeringUnits KilowattHoursPerSquareMeter = new EngineeringUnits(137);
        public static readonly EngineeringUnits KilowattHoursPerSquareFoot = new EngineeringUnits(138);
        public static readonly EngineeringUnits MegajoulesPerSquareMeter = new EngineeringUnits(139);
        public static readonly EngineeringUnits MegajoulesPerSquareFoot = new EngineeringUnits(140);
        public static readonly EngineeringUnits NoUnits = new EngineeringUnits(95);
        public static readonly EngineeringUnits NewtonSeconds = new EngineeringUnits(187);
        public static readonly EngineeringUnits NewtonsPerMeter = new EngineeringUnits(188);
        public static readonly EngineeringUnits PartsPerMillion = new EngineeringUnits(96);
        public static readonly EngineeringUnits PartsPerBillion = new EngineeringUnits(97);
        public static readonly EngineeringUnits Percent = new EngineeringUnits(98);
        public static readonly EngineeringUnits PercentObscurationPerFoot = new EngineeringUnits(143);
        public static readonly EngineeringUnits PercentObscurationPerMeter = new EngineeringUnits(144);
        public static readonly EngineeringUnits PercentPerSecond = new EngineeringUnits(99);
        public static readonly EngineeringUnits PerMinute = new EngineeringUnits(100);
        public static readonly EngineeringUnits PerSecond = new EngineeringUnits(101);
        public static readonly EngineeringUnits PsiPerDegreeFahrenheit = new EngineeringUnits(102);
        public static readonly EngineeringUnits Radians = new EngineeringUnits(103);
        public static readonly EngineeringUnits RadiansPerSecond = new EngineeringUnits(184);
        public static readonly EngineeringUnits RevolutionsPerMinute = new EngineeringUnits(104);
        public static readonly EngineeringUnits SquareMetersPerNewton = new EngineeringUnits(185);
        public static readonly EngineeringUnits WattsPerMeterPerDegreeKelvin = new EngineeringUnits(189);
        public static readonly EngineeringUnits WattsPerSquareMeterDegreeKelvin = new EngineeringUnits(141);

        public static readonly EngineeringUnits[] All =
        {
            SquareMeters, SquareFeet, Milliamperes, Amperes, Ohms, Volts,
            Kilovolts, Megavolts, VoltAmperes, KilovoltAmperes, MegavoltAmperes, VoltAmperesReactive,
            KilovoltAmperesReactive, MegavoltAmperesReactive, DegreesPhase, PowerFactor, Joules, Kilojoules, WattHours,
            KilowattHours, Btus, Therms, TonHours, JoulesPerKilogramDryAir, BtusPerPoundDryAir, CyclesPerHour,
            CyclesPerMinute, Hertz, GramsOfWaterPerKilogramDryAir, PercentRelativeHumidity, Millimeters, Meters,
            Inches, Feet, WattsPerSquareFoot, WattsPerSquareMeter, Lumens, Luxes, FootCandles, Kilograms, PoundsMass,
            Tons, KilogramsPerSecond, KilogramsPerMinute, KilogramsPerHour, PoundsMassPerMinute, PoundsMassPerHour,
            Watts, Kilowatts, Megawatts, BtusPerHour, Horsepower, TonsRefrigeration, Pascals, Kilopascals, Bars,
            PoundsForcePerSquareInch, CentimetersOfWater, InchesOfWater, MillimetersOfMercury, CentimetersOfMercury,
            InchesOfMercury, DegreesCelsius, DegreesKelvin, DegreesFahrenheit, DegreeDaysCelsius, DegreeDaysFahrenheit,
            Years, Months, Weeks, Days, Hours, Minutes, Seconds, MetersPerSecond, KilometersPerHour, FeetPerSecond,
            FeetPerMinute, MilesPerHour, CubicFeet, CubicMeters, ImperialGallons, Liters, UsGallons,
            CubicFeetPerMinute, CubicMetersPerSecond, ImperialGallonsPerMinute, LitersPerSecond, LitersPerMinute,
            UsGallonsPerMinute, DegreesAngular, DegreesCelsiusPerHour, DegreesCelsiusPerMinute,
            DegreesFahrenheitPerHour, DegreesFahrenheitPerMinute, NoUnits, PartsPerMillion, PartsPerBillion, Percent,
            PercentPerSecond, PerMinute, PerSecond, PsiPerDegreeFahrenheit, Radians, RevolutionsPerMinute, Currency1,
            Currency2, Currency3, Currency4, Currency5, Currency6, Currency7, Currency8, Currency9, Currency10,
            SquareInches, SquareCentimeters, BtusPerPound, Centimeters, PoundsMassPerSecond, DeltaDegreesFahrenheit,
            DeltaDegreesKelvin, Kilohms, Megohms, Millivolts, KilojoulesPerKilogram, Megajoules, JoulesPerDegreeKelvin,
            JoulesPerKilogramDegreeKelvin, Kilohertz, Megahertz, PerHour, Milliwatts, Hectopascals, Millibars,
            CubicMetersPerHour, LitersPerHour, KilowattHoursPerSquareMeter, KilowattHoursPerSquareFoot,
            MegajoulesPerSquareMeter, MegajoulesPerSquareFoot, WattsPerSquareMeterDegreeKelvin, CubicFeetPerSecond,
            PercentObscurationPerFoot, PercentObscurationPerMeter, Milliohms, MegawattHours, KiloBtus, MegaBtus,
            KilojoulesPerKilogramDryAir, MegajoulesPerKilogramDryAir, KilojoulesPerDegreeKelvin,
            MegajoulesPerDegreeKelvin, Newton, GramsPerSecond, GramsPerMinute, TonsPerHour, KiloBtusPerHour,
            HundredthsSeconds, Milliseconds, NewtonMeters, MillimetersPerSecond, MillimetersPerMinute, MetersPerMinute,
            MetersPerHour, CubicMetersPerMinute, MetersPerSecondPerSecond, AmperesPerMeter, AmperesPerSquareMeter,
            AmpereSquareMeters, Farads, Henrys, OhmMeters, Siemens, SiemensPerMeter, Teslas, VoltsPerDegreeKelvin,
            VoltsPerMeter, Webers, Candelas, CandelasPerSquareMeter, DegreesKelvinPerHour, DegreesKelvinPerMinute,
            JouleSeconds, RadiansPerSecond, SquareMetersPerNewton, KilogramsPerCubicMeter, NewtonSeconds,
            NewtonsPerMeter, WattsPerMeterPerDegreeKelvin
        };

        public EngineeringUnits(uint value) : base(value)
        {
        }

        public EngineeringUnits(ByteStream queue) : base(queue)
        {
        }


        public override string ToString()
        {
            uint type = Value;
            if (type == MetersPerSecondPerSecond.Value)
                return "meters per second per second";
            if (type == SquareMeters.Value)
                return "square meters";
            if (type == SquareCentimeters.Value)
                return "square centimeters";
            if (type == SquareFeet.Value)
                return "square feet";
            if (type == SquareInches.Value)
                return "square inches";
            if (type == Currency1.Value)
                return "currency 1";
            if (type == Currency2.Value)
                return "currency 2";
            if (type == Currency3.Value)
                return "currency 3";
            if (type == Currency4.Value)
                return "currency 4";
            if (type == Currency5.Value)
                return "currency 5";
            if (type == Currency6.Value)
                return "currency 6";
            if (type == Currency7.Value)
                return "currency 7";
            if (type == Currency8.Value)
                return "currency 8";
            if (type == Currency9.Value)
                return "currency 9";
            if (type == Currency10.Value)
                return "currency 10";
            if (type == Milliamperes.Value)
                return "milliamperes";
            if (type == Amperes.Value)
                return "amperes";
            if (type == AmperesPerMeter.Value)
                return "amperes per meter";
            if (type == AmperesPerSquareMeter.Value)
                return "amperes per square meter";
            if (type == AmpereSquareMeters.Value)
                return "ampere square meters";
            if (type == Farads.Value)
                return "farads";
            if (type == Henrys.Value)
                return "henrys";
            if (type == Ohms.Value)
                return "ohms";
            if (type == OhmMeters.Value)
                return "ohm meters";
            if (type == Milliohms.Value)
                return "milliohms";
            if (type == Kilohms.Value)
                return "kilohms";
            if (type == Megohms.Value)
                return "megohms";
            if (type == Siemens.Value)
                return "siemens";
            if (type == SiemensPerMeter.Value)
                return "siemens per meter";
            if (type == Teslas.Value)
                return "teslas";
            if (type == Volts.Value)
                return "volts";
            if (type == Millivolts.Value)
                return "millivolts";
            if (type == Kilovolts.Value)
                return "kilovolts";
            if (type == Megavolts.Value)
                return "megavolts";
            if (type == VoltAmperes.Value)
                return "volt amperes";
            if (type == KilovoltAmperes.Value)
                return "kilovolt amperes";
            if (type == MegavoltAmperes.Value)
                return "megavolt amperes";
            if (type == VoltAmperesReactive.Value)
                return "volt amperes reactive";
            if (type == KilovoltAmperesReactive.Value)
                return "kilovolt amperes reactive";
            if (type == MegavoltAmperesReactive.Value)
                return "megavolt amperes reactive";
            if (type == VoltsPerDegreeKelvin.Value)
                return "volts per degree kelvin";
            if (type == VoltsPerMeter.Value)
                return "volts per meter";
            if (type == DegreesPhase.Value)
                return "degrees phase";
            if (type == PowerFactor.Value)
                return "power factor";
            if (type == Webers.Value)
                return "webers";
            if (type == Joules.Value)
                return "joules";
            if (type == Kilojoules.Value)
                return "kilojoules";
            if (type == KilojoulesPerKilogram.Value)
                return "kilojoules per kilogram";
            if (type == Megajoules.Value)
                return "megajoules";
            if (type == WattHours.Value)
                return "watt hours";
            if (type == KilowattHours.Value)
                return "kilowatt hours";
            if (type == MegawattHours.Value)
                return "megawatt hours";
            if (type == Btus.Value)
                return "btus";
            if (type == KiloBtus.Value)
                return "kilo btus";
            if (type == MegaBtus.Value)
                return "mega btus";
            if (type == Therms.Value)
                return "therms";
            if (type == TonHours.Value)
                return "ton hours";
            if (type == JoulesPerKilogramDryAir.Value)
                return "joules per kilogram dry air";
            if (type == KilojoulesPerKilogramDryAir.Value)
                return "kilojoules per kilogram dry air";
            if (type == MegajoulesPerKilogramDryAir.Value)
                return "megajoules per kilogram dry air";
            if (type == BtusPerPoundDryAir.Value)
                return "btus per pound dry air";
            if (type == BtusPerPound.Value)
                return "btus per pound";
            if (type == JoulesPerDegreeKelvin.Value)
                return "joules per degree kelvin";
            if (type == KilojoulesPerDegreeKelvin.Value)
                return "kilojoules per degree kelvin";
            if (type == MegajoulesPerDegreeKelvin.Value)
                return "megajoules per degree kelvin";
            if (type == JoulesPerKilogramDegreeKelvin.Value)
                return "joules per kilogram degree kelvin";
            if (type == Newton.Value)
                return "newton";
            if (type == CyclesPerHour.Value)
                return "cycles per hour";
            if (type == CyclesPerMinute.Value)
                return "cycles per minute";
            if (type == Hertz.Value)
                return "hertz";
            if (type == Kilohertz.Value)
                return "kilohertz";
            if (type == Megahertz.Value)
                return "megahertz";
            if (type == PerHour.Value)
                return "per hour";
            if (type == GramsOfWaterPerKilogramDryAir.Value)
                return "grams of water per kilogram dry air";
            if (type == PercentRelativeHumidity.Value)
                return "percent relative humidity";
            if (type == Millimeters.Value)
                return "millimeters";
            if (type == Centimeters.Value)
                return "centimeters";
            if (type == Meters.Value)
                return "meters";
            if (type == Inches.Value)
                return "inches";
            if (type == Feet.Value)
                return "feet";
            if (type == Candelas.Value)
                return "candelas";
            if (type == CandelasPerSquareMeter.Value)
                return "candelas per square meter";
            if (type == WattsPerSquareFoot.Value)
                return "watts per square foot";
            if (type == WattsPerSquareMeter.Value)
                return "watts per square meter";
            if (type == Lumens.Value)
                return "lumens";
            if (type == Luxes.Value)
                return "luxes";
            if (type == FootCandles.Value)
                return "foot candles";
            if (type == Kilograms.Value)
                return "kilograms";
            if (type == PoundsMass.Value)
                return "pounds mass";
            if (type == Tons.Value)
                return "tons";
            if (type == GramsPerSecond.Value)
                return "grams per second";
            if (type == GramsPerMinute.Value)
                return "grams per minute";
            if (type == KilogramsPerSecond.Value)
                return "kilograms per second";
            if (type == KilogramsPerMinute.Value)
                return "kilograms per minute";
            if (type == KilogramsPerHour.Value)
                return "kilograms per hour";
            if (type == PoundsMassPerSecond.Value)
                return "pounds mass per second";
            if (type == PoundsMassPerMinute.Value)
                return "pounds mass per minute";
            if (type == PoundsMassPerHour.Value)
                return "pounds mass per hour";
            if (type == TonsPerHour.Value)
                return "tons per hour";
            if (type == Milliwatts.Value)
                return "milliwatts";
            if (type == Watts.Value)
                return "watts";
            if (type == Kilowatts.Value)
                return "kilowatts";
            if (type == Megawatts.Value)
                return "megawatts";
            if (type == BtusPerHour.Value)
                return "btus per hour";
            if (type == KiloBtusPerHour.Value)
                return "kilo btus per hour";
            if (type == Horsepower.Value)
                return "horsepower";
            if (type == TonsRefrigeration.Value)
                return "tons refrigeration";
            if (type == Pascals.Value)
                return "pascals";
            if (type == Hectopascals.Value)
                return "hectopascals";
            if (type == Kilopascals.Value)
                return "kilopascals";
            if (type == Millibars.Value)
                return "millibars";
            if (type == Bars.Value)
                return "bars";
            if (type == PoundsForcePerSquareInch.Value)
                return "pounds force per square inch";
            if (type == CentimetersOfWater.Value)
                return "centimeters of water";
            if (type == InchesOfWater.Value)
                return "inches of water";
            if (type == MillimetersOfMercury.Value)
                return "millimeters of mercury";
            if (type == CentimetersOfMercury.Value)
                return "centimeters of mercury";
            if (type == InchesOfMercury.Value)
                return "inches of mercury";
            if (type == DegreesCelsius.Value)
                return "degrees celsius";
            if (type == DegreesKelvin.Value)
                return "degrees kelvin";
            if (type == DegreesKelvinPerHour.Value)
                return "degrees kelvin per hour";
            if (type == DegreesKelvinPerMinute.Value)
                return "degrees kelvin per minute";
            if (type == DegreesFahrenheit.Value)
                return "degrees fahrenheit";
            if (type == DegreeDaysCelsius.Value)
                return "degree days celsius";
            if (type == DegreeDaysFahrenheit.Value)
                return "degree days fahrenheit";
            if (type == DeltaDegreesFahrenheit.Value)
                return "delta degrees fahrenheit";
            if (type == DeltaDegreesKelvin.Value)
                return "delta degrees kelvin";
            if (type == Years.Value)
                return "years";
            if (type == Months.Value)
                return "months";
            if (type == Weeks.Value)
                return "weeks";
            if (type == Days.Value)
                return "days";
            if (type == Hours.Value)
                return "hours";
            if (type == Minutes.Value)
                return "minutes";
            if (type == Seconds.Value)
                return "seconds";
            if (type == HundredthsSeconds.Value)
                return "hundredths seconds";
            if (type == Milliseconds.Value)
                return "milliseconds";
            if (type == NewtonMeters.Value)
                return "newton meters";
            if (type == MillimetersPerSecond.Value)
                return "millimeters per second";
            if (type == MillimetersPerMinute.Value)
                return "millimeters per minute";
            if (type == MetersPerSecond.Value)
                return "meters per second";
            if (type == MetersPerMinute.Value)
                return "meters per minute";
            if (type == MetersPerHour.Value)
                return "meters per hour";
            if (type == KilometersPerHour.Value)
                return "kilometers per hour";
            if (type == FeetPerSecond.Value)
                return "feet per second";
            if (type == FeetPerMinute.Value)
                return "feet per minute";
            if (type == MilesPerHour.Value)
                return "miles per hour";
            if (type == CubicFeet.Value)
                return "cubic feet";
            if (type == CubicMeters.Value)
                return "cubic meters";
            if (type == ImperialGallons.Value)
                return "imperial gallons";
            if (type == Liters.Value)
                return "liters";
            if (type == UsGallons.Value)
                return "us gallons";
            if (type == CubicFeetPerSecond.Value)
                return "cubic feet per second";
            if (type == CubicFeetPerMinute.Value)
                return "cubic feet per minute";
            if (type == CubicMetersPerSecond.Value)
                return "cubic meters per second";
            if (type == CubicMetersPerMinute.Value)
                return "cubic meters per minute";
            if (type == CubicMetersPerHour.Value)
                return "cubic meters per hour";
            if (type == ImperialGallonsPerMinute.Value)
                return "imperial gallons per minute";
            if (type == LitersPerSecond.Value)
                return "liters per second";
            if (type == LitersPerMinute.Value)
                return "liters per minute";
            if (type == LitersPerHour.Value)
                return "liters per hour";
            if (type == UsGallonsPerMinute.Value)
                return "us gallons per minute";
            if (type == DegreesAngular.Value)
                return "degrees angular";
            if (type == DegreesCelsiusPerHour.Value)
                return "degrees celsius per hour";
            if (type == DegreesCelsiusPerMinute.Value)
                return "degrees celsius per minute";
            if (type == DegreesFahrenheitPerHour.Value)
                return "degrees fahrenheit per hour";
            if (type == DegreesFahrenheitPerMinute.Value)
                return "degrees fahrenheit per minute";
            if (type == JouleSeconds.Value)
                return "joule seconds";
            if (type == KilogramsPerCubicMeter.Value)
                return "kilograms per cubic meter";
            if (type == KilowattHoursPerSquareMeter.Value)
                return "kilowatt hours per square meter";
            if (type == KilowattHoursPerSquareFoot.Value)
                return "kilowatt hours per square foot";
            if (type == MegajoulesPerSquareMeter.Value)
                return "megajoules per square meter";
            if (type == MegajoulesPerSquareFoot.Value)
                return "megajoules per square foot";
            if (type == NoUnits.Value)
                return "";
            if (type == NewtonSeconds.Value)
                return "newton seconds";
            if (type == NewtonsPerMeter.Value)
                return "newtons per meter";
            if (type == PartsPerMillion.Value)
                return "parts per million";
            if (type == PartsPerBillion.Value)
                return "parts per billion";
            if (type == Percent.Value)
                return "percent";
            if (type == PercentObscurationPerFoot.Value)
                return "percent obscuration per foot";
            if (type == PercentObscurationPerMeter.Value)
                return "percent obscuration per meter";
            if (type == PercentPerSecond.Value)
                return "percent per second";
            if (type == PerMinute.Value)
                return "per minute";
            if (type == PerSecond.Value)
                return "per second";
            if (type == PsiPerDegreeFahrenheit.Value)
                return "psi per degree fahrenheit";
            if (type == Radians.Value)
                return "radians";
            if (type == RadiansPerSecond.Value)
                return "radians per second";
            if (type == RevolutionsPerMinute.Value)
                return "revolutions per minute";
            if (type == SquareMetersPerNewton.Value)
                return "square meters per Newton";
            if (type == WattsPerMeterPerDegreeKelvin.Value)
                return "watts per meter per degree kelvin";
            if (type == WattsPerSquareMeterDegreeKelvin.Value)
                return "watts per square meter degree kelvin";
            return "Unknown: " + type;
        }
    }
}
