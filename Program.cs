// See https://aka.ms/new-console-template for more information
Console.WriteLine("Started File Mover...");

DirectoryInfo sourceFolder = new DirectoryInfo(@"D:\Jonnys Camera Pictures"); 
DirectoryInfo destFolder = new DirectoryInfo(@"D:\Jonnys Camera Pictures\Sorted"); 

Console.WriteLine("Moving From: "+sourceFolder.FullName);
Console.WriteLine("Moving To: "+destFolder.FullName);

FileInfo[] jpgFiles = sourceFolder.GetFiles("*.jpg");
FileInfo[] rafFiles = sourceFolder.GetFiles("*.raf");

foreach(var jpgFile in jpgFiles)
{
    string fileYear= jpgFile.CreationTime.Year.ToString();
    string fileYearMonth=jpgFile.CreationTime.Year + "_" + jpgFile.CreationTime.Month;
    string fileDay=jpgFile.CreationTime.Year + "_" + jpgFile.CreationTime.Month + "_" +jpgFile.CreationTime.Day;

    var yearPath = Path.Combine(destFolder.FullName,fileYear);
    var monthPath = Path.Combine(destFolder.FullName,yearPath,fileYearMonth);
    var dayPath = Path.Combine(destFolder.FullName,yearPath,fileYearMonth,fileDay);

    //Year Month Dated Folder
    if(!Directory.Exists(yearPath))
    {
        Directory.CreateDirectory(yearPath);
        Console.WriteLine("Created: "+yearPath);
    }
    //Year Month Dated Folder
    if(!Directory.Exists(monthPath))
    {
        Directory.CreateDirectory(monthPath);
         Console.WriteLine("Created: "+monthPath);
    }
    //Day Folder
    if(!Directory.Exists(dayPath))
    {
        Directory.CreateDirectory(dayPath);
        Console.WriteLine("Created: "+dayPath);
    }
    //move the file to dated folder
    jpgFile.MoveTo(@$"{dayPath}\{jpgFile.Name}");
    Console.WriteLine("Moved to: "+jpgFile.FullName);
}

foreach(var rafFile in rafFiles)
{
    string fileYear= rafFile.CreationTime.Year.ToString();
    string fileYearMonth=rafFile.CreationTime.Year + "_" + rafFile.CreationTime.Month;
    string fileDay=rafFile.CreationTime.Year + "_" + rafFile.CreationTime.Month +"_" +rafFile.CreationTime.Day;

    var yearPath = Path.Combine(destFolder.FullName,fileYear);
    var monthPath = Path.Combine(destFolder.FullName,yearPath,fileYearMonth);
    var dayPath = Path.Combine(destFolder.FullName,yearPath,fileYearMonth,fileDay);
    string rafPath = Path.Combine(destFolder.FullName,yearPath,fileYearMonth,fileDay,"RAF");

    //Year Month Dated Folder
    if(!Directory.Exists(yearPath))
    {
        Directory.CreateDirectory(yearPath);
        Console.WriteLine("Created: "+yearPath);
    }
    //Year Month Dated Folder
    if(!Directory.Exists(monthPath))
    {
        Directory.CreateDirectory(monthPath);
        Console.WriteLine("Created: "+monthPath);
    }
    //Day Folder
    if(!Directory.Exists(dayPath))
    {
        Directory.CreateDirectory(dayPath);
        Console.WriteLine("Created: "+dayPath);
    }
    //create a RAF folder in the file if it doesnt exist already
    if(!Directory.Exists(rafPath))
    {
        Directory.CreateDirectory(rafPath);
        Console.WriteLine("Created: "+rafPath);
    }
    //move the file to the RAF folder
    rafFile.MoveTo(@$"{rafPath}\{rafFile.Name}");
    Console.WriteLine("Moved to: "+rafFile.FullName);
}
Console.WriteLine("Finished Moving Files!");
Console.WriteLine("Press any key to close...");
Console.ReadLine();