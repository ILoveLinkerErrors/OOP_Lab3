
class TTRiangle {
    private double sideA;
    private double sideB;
    private double sideC;

    private bool isInitialized = false;

    private static readonly double EPSILON = 1e-8;

    public enum Sides {
        SideA = 1,
        SideB = 2, 
        SideC = 3,
    }

    private static void ThrowFatalError(string msg) {
        Console.Error.WriteLine("Fatal Error: {0}", msg);
        Environment.Exit(1);
    }
    
    public double SideA
    {
        get {
            return sideA; 
        }
        set { 
            if (value < EPSILON) {
                ThrowFatalError("triangle side <A> must be bigger than 0.");
            }
            if (isInitialized) {
                if (!IsValidTriangle(value, sideB, sideC)) {
                    ThrowFatalError(string.Format("current lengths of sides <B>, <C> and {0} do not form a valid triangle.", value));
                }
            }
            sideA = value; 
        }
    }

    public double SideB
    {
        get { 
            return sideB; 
        }
        set {
            if (value < EPSILON) {
                ThrowFatalError("triangle side <B> must be bigger than 0");
            }
            if (isInitialized) {
                if (!IsValidTriangle(SideA, value, sideC)) {
                    ThrowFatalError("current lengths of sides <A>, <C> and {0} do not form a valid triangle.");
                }
            }
            sideB = value; 
        }
    }
    public double SideC
    {
        get { 
            return sideC; 
        }
        set { 
            if (value < EPSILON) {
                ThrowFatalError("triangle side <C> must be bigger than 0.");
            }
            if (isInitialized) {
                if (!IsValidTriangle(SideA, SideB, value)) {
                    ThrowFatalError("current lengths of sides <A>, <B> and {0} do not form a valid triangle.");
                }
            }
            sideC = value; 
        }
    }

    private static bool IsValidTriangle(double a, double b, double c) {
        if (a < EPSILON || b < EPSILON || c < EPSILON) {
            return false;
        }
        return a + b - c > EPSILON && a + c - b > EPSILON && b + c - a > EPSILON;
    }

    public TTRiangle(double A, double B, double C) {  
        if (!IsValidTriangle(A, B, C)) {
            ThrowFatalError(string.Format("sides {0}, {1}, {2} do not form a valid triangle.", A, B, C));
        }   
        sideA = A;
        sideB = B;
        sideC = C;
        isInitialized = true;
    }

    public TTRiangle() {
        SideA = 1;
        SideB = 1;
        SideC = 1;
        isInitialized = true;
    }

    public void Print() {
        Console.WriteLine("\nTriangle sides: ");
        Console.WriteLine("Side<A> = {0}", SideA);
        Console.WriteLine("Side<B> = {0}", SideB);
        Console.WriteLine("Side<C> = {0}", SideC);
    }

    public double GetPerimeter() {
        return SideA + SideB + SideC;
    }

    public double GetArea() {
        double halfPerim = 0.5 * GetPerimeter();
        return Math.Sqrt(halfPerim * (halfPerim - SideA) * (halfPerim - SideB) * (halfPerim - SideC));
    }

    public double this[int i] {
        get {
            return i switch
            {
                1 => SideA,
                2 => SideB,
                3 => SideC,
                _ => 0,
            };
        }
        set {
            switch (i) {
                case 1: 
                SideA = value;
                break;
                case 2:
                SideB = value;
                break;
                case 3:
                SideC = value;
                break;
            }
        }
    }
        public double this[Sides side] {
        get {
            return side switch
            {
                Sides.SideA => SideA,
                Sides.SideB => SideB,
                Sides.SideC => SideC,
                _ => 0,
            };
        }
        set {
            switch (side) {
                case Sides.SideA:
                SideA = value;
                break;
                case Sides.SideB:
                SideB = value;
                break;
                case Sides.SideC:
                SideC = value;
                break;
            }
        }
    }
}