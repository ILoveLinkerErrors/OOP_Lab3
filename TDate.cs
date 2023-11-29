
class TDate {
    private uint day;
    private uint month = 0;
    private uint year = 0;

    private struct MonthData {
    public int days;
    public string name;
    }

    private MonthData[] MonthLookUpTable = { 
        new() {days = 31, name = "January"}, 
        new() {days = 28, name = "February"}, 
        new() {days = 31, name = "March"}, 
        new() {days = 30, name = "April"},
        new() {days = 31, name = "May"}, 
        new() {days = 30, name = "June"}, 
        new() {days = 31, name = "July"}, 
        new() {days = 31, name = "August"},
        new() {days = 30, name = "September"}, 
         new() {days = 31, name = "October"}, 
         new() {days = 30, name = "November"}, 
         new() {days = 31, name = "December" }
    };

    private static void ThrowFatalError(string msg) {
        Console.Error.WriteLine("Fatal Error: {0}", msg);
        Environment.Exit(1);
    }

    public uint Year {
        get {
            return year;
        }
        set {
            if (value < 1 || value > 9999) {
                ThrowFatalError("year number must be in range 1 - 9999");
            }
            year = value;
            if (year % 4 == 0) { // check if year is a leap year
                MonthLookUpTable[1].days = 29;
            } else {
                MonthLookUpTable[1].days = 28;
            }
        }
    }

    public uint Month {
        get {
            return month;
        }
        set {
            if (value > 12 || value < 1) { 
                ThrowFatalError("month number has to be in range 1 - 12");
            }
            month = value;
        }
    }   

    public uint Day {
        get {
            return day;
        }
        set {
            if (month == 0 || year == 0) {
                ThrowFatalError("first set year and month before setting day");
            }
            var currMonthData = MonthLookUpTable[Month - 1];
            if (value > currMonthData.days || value < 1) {
                ThrowFatalError(string.Format("current month ({0}) can have the day value in range 1 - {1}", currMonthData.name, currMonthData.days));
            }
            day = value;
        }
    }

    public override string ToString() {
        string dayStr = Day < 10 ? "0" + Day.ToString() : Day.ToString();
        string monthStr = Month < 10 ? "0" + Month.ToString() : Month.ToString();
        var yearStr = year.ToString();
        for (int i = 0; i < 4 - yearStr.Length; i++)
        {   
            yearStr = "0" + yearStr;
        }
        return dayStr + "/" + monthStr + "/" + yearStr;
    }   

    public TDate() {
        var dateNow = DateTime.Now;
        Year = (uint)dateNow.Year;
        Month = (uint)dateNow.Month;
        Day = (uint)dateNow.Day;
    }

    public TDate(uint year, uint month, uint day) {
        Year = year;
        Month = month;
        Day = day;
    }
}