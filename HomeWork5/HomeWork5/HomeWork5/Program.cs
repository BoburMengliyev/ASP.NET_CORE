
//namespace HomeWork5
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            builder.Services.AddControllers();

//            builder.Services.AddOpenApi();

//            var app = builder.Build();

//            if (app.Environment.IsDevelopment())
//            {
//                app.MapOpenApi();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();

//            app.MapControllers();

//            app.Run();
//        }
//    }
//}


class Program
{
    static void Main()
    {
        // Task 1:
        Console.WriteLine("Task 1: ");
        string directoryPath = @"C:\Temp";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Console.WriteLine("'C:\\Temp' papkasi yaratildi.");
        }
        else
        {
            Console.WriteLine("'C:\\Temp' papkasi mavjud.");
        }
        Console.WriteLine("###############################################");

        // Task 2:
        Console.WriteLine("Task 2: ");
        string filePath = Path.Combine(directoryPath, "test.txt");

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            Console.WriteLine("'test.txt' fayli yaratildi.");
        }
        else
        {
            Console.WriteLine("'test.txt' fayli allaqachon mavjud.");
        }
        Console.WriteLine("###############################################");

        // Task 3:
        Console.WriteLine("Task 3: ");
        FileInfo fileInfo = new FileInfo(filePath);
        Console.WriteLine("Fayl nomi: " + fileInfo.Name);
        Console.WriteLine("To‘liq yo‘l: " + fileInfo.FullName);
        Console.WriteLine("Yaratilgan sana: " + fileInfo.CreationTime);
        Console.WriteLine("Hajmi (baytda): " + fileInfo.Length);
        Console.WriteLine("###############################################");

        // Task 4:
        Console.WriteLine("Task 4: ");
        string subFolderPath = Path.Combine(directoryPath, "SubFolder");
        Console.WriteLine("Yangi yo‘l (birlashtirilgan): " + subFolderPath);
        Console.WriteLine("###############################################");

        // Task 5:
        Console.WriteLine("Task 5: ");
        string textToWrite = "Salom, bu test faylidir!";
        File.WriteAllText(filePath, textToWrite);
        Console.WriteLine("Faylga yozildi: " + textToWrite);

        string readText = File.ReadAllText(filePath);
        Console.WriteLine("Fayldan o‘qildi: " + readText);
        Console.WriteLine("###############################################");
    }
}