TDate myDate = new();
Console.WriteLine("myDate = {0}", myDate);
myDate.Year = 144;
myDate.Month = 5;
myDate.Day = 23;
Console.WriteLine("myDate = {0}", myDate);

TTRiangle myTri = new(3, 4, 5);
myTri[TTRiangle.Sides.SideA] = 1;