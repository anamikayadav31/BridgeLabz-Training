using Newtonsoft.Json;

class Car
{
    public string Brand { get; set; }
    public int Year { get; set; }
}

class CarToJson
{
    static void Main()
    {
        Car car = new Car { Brand = "BMW", Year = 2023 };
        string json = JsonConvert.SerializeObject(car, Formatting.Indented);
        Console.WriteLine(json);
    }
}
