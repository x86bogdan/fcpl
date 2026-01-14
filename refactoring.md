# Refactoring Challenges

Focus: Transforming verbose, procedural legacy code into concise, modern C#.

Exercise A: The Inventory Report (LINQ Mastery)

Context: A legacy reporting module manually iterates through inventory to generate a summary text file. It filters, sorts, formats, and concatenates strings manually.

The Task: Replace the entire 40-line method with a single LINQ chain (or 2-3 lines max).

The Legacy Code
```
public List<string> GenerateLowStockReport(List<Product> products)
{
    List<Product> filtered = new List<Product>();
    
    // 1. Filter: Active and Low Stock
    foreach (var p in products)
    {
        if (p.IsActive)
        {
            if (p.StockCount < 10)
            {
                filtered.Add(p);
            }
        }
    }

    // 2. Sort: Manual Bubble Sort by Name
    for (int i = 0; i < filtered.Count; i++)
    {
        for (int j = 0; j < filtered.Count - 1; j++)
        {
            if (string.Compare(filtered[j].Name, filtered[j + 1].Name) > 0)
            {
                var temp = filtered[j];
                filtered[j] = filtered[j + 1];
                filtered[j + 1] = temp;
            }
        }
    }

    // 3. Format: Create output strings
    List<string> report = new List<string>();
    foreach (var p in filtered)
    {
        string line = "ITEM: " + p.Name.ToUpper() + " - QTY: " + p.StockCount;
        report.Add(line);
    }

    return report;
}
```

Exercise B: The Discount Engine (Pattern Matching)

Context: A legacy business logic method calculates a discount percentage based on User Tier, Years of Membership, and Order Total. It uses a massive, nested if-else structure that is hard to read.

The Task: Replace the logic with a C# 8+ Switch Expression using Tuple Patterns.

The Legacy Code
```
public decimal CalculateDiscount(User user, decimal orderTotal)
{
    decimal discount = 0;

    if (user.Type == "VIP")
    {
        if (user.YearsActive > 5)
        {
            discount = 0.20m; // 20%
        }
        else
        {
            if (orderTotal > 100)
            {
                discount = 0.15m;
            }
            else
            {
                discount = 0.10m;
            }
        }
    }
    else if (user.Type == "Regular")
    {
        if (orderTotal > 200)
        {
            discount = 0.05m;
        }
        else
        {
            discount = 0;
        }
    }
    else if (user.Type == "Employee")
    {
        discount = 0.50m; // 50% flat
    }

    return discount;
}
```

Exercise C: The Data Mapper (Object Initialization)

Context: Mapping data from a database entity (e.g., UserEntity) to a view model (UserViewModel). The legacy code manually checks for nulls and assigns properties one by one, often handling lists manually.

The Task: Simplify the object creation using Object Initializers and LINQ.

The Legacy Code
```
public List<UserDto> ConvertUsers(List<UserEntity> entities)
{
    List<UserDto> dtos = new List<UserDto>();

    if (entities != null)
    {
        foreach (var entity in entities)
        {
            if (entity.IsDeleted == false)
            {
                UserDto dto = new UserDto();
                dto.Id = entity.Id;
                
                if (entity.FullName != null)
                    dto.Name = entity.FullName;
                else
                    dto.Name = "Unknown";

                dto.Email = entity.EmailAddress;
                dto.Role = entity.AccessLevel.ToString();
                
                dtos.Add(dto);
            }
        }
    }
    return dtos;
}
```

Exercise D: The String Cleaner (String Manipulation)

Context: A method takes raw input (e.g., from a CSV or user input), cleans it, removes bad characters, capitalizes it, and joins it back together. The legacy code acts like a C program, manipulating char arrays manually.

The Task: Use modern string methods (Split, Trim, Join) and LINQ.

The Legacy Code
```
public string CleanAndFormatTags(string rawInput)
{
    // Input example: "  c#,  asp.net , sql-server,   "
    if (rawInput == null) return "";

    string result = "";
    string currentWord = "";

    for (int i = 0; i < rawInput.Length; i++)
    {
        char c = rawInput[i];
        if (c == ',')
        {
            if (currentWord.Trim().Length > 0)
            {
                if (result.Length > 0) result += "|";
                result += currentWord.Trim().ToUpper();
            }
            currentWord = "";
        }
        else
        {
            currentWord += c;
        }
    }
    // Handle last word
    if (currentWord.Trim().Length > 0)
    {
        if (result.Length > 0) result += "|";
        result += currentWord.Trim().ToUpper();
    }
    
    return result;
}
```

Exercise E: The "Switch Statement from Hell" (State Pattern)

Context: A class managing an Order is using a giant switch statement to control behavior based on status. This violates the Open/Closed principle. Refactor it using the State Pattern.

The Legacy Code:
```
public class Order {
    public string State { get; set; } = "New";

    public void Cancel() {
        if (State == "New") {
            State = "Cancelled";
            Console.WriteLine("Order cancelled.");
        } else if (State == "Shipped") {
            Console.WriteLine("Cannot cancel! Already shipped.");
        } else if (State == "Cancelled") {
            Console.WriteLine("Already cancelled.");
        }
    }

    public void Ship() {
        if (State == "New") {
            State = "Shipped";
            Console.WriteLine("Order shipped.");
        } else if (State == "Shipped") {
            Console.WriteLine("Already shipped.");
        } else if (State == "Cancelled") {
            Console.WriteLine("Cannot ship a cancelled order.");
        }
    }
}
```
