using System;

public class Gear {
    public struct Parameters {
        public double PD, PA_PD, CSW_PD, CTT_PD, PITCH;
        public uint NT;
        public double ROOT, FILLET, FORM;
    }

	public class External {
        private double PD, PA_PD, CTT_PD;
        private uint NT;
        private double ROOT, FILLET, FORM;

        public External(double PD = 0, double PA_PD = 0, double CSW_PD = 0, double CTT_PD = 0, double PITCH = 0,
            uint NT = 0, double ROOT = 0, double FILLET = 0, double FORM = 0) {
            this.NT = NT;
            this.PA_PD = PA_PD;
            if (PD == 0) this.PD = NT / PITCH;
            if (CTT_PD == 0) this.CTT_PD = Math.PI * this.PD / NT - CSW_PD;
            this.ROOT = ROOT;
            this.FILLET = FILLET;
            this.FORM = FORM;
        }

        public double CTT(double D) {
            return D * (CTT_PD / PD + Math.Tan(Math.Acos(BD / PD)) - Math.Acos(BD / PD) - Math.Tan(Math.Acos(BD / D)) + Math.Acos(BD / D));
        }

        public double CSW(double D) {
            return Math.PI * D / NT - CTT(D);
        }

        public double BD { get => PD * Math.Cos(PA_PD); }

        public double OD {
            get {
                double recur(double U, double L) {
                    double D = (U + L) / 2, CTT_D = CTT(D);
                    if (CTT_D > 0.00000001) return recur(D, U);
                    if (CTT_D < -0.00000001) return recur(L, D);
                    return D;
                }
                return recur(PD, 2 * PD);
            }
        }
    }

    public class Internal
    {
        public Internal(Parameters input)
        {

        }
    }
}
