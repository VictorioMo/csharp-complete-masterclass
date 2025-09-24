# SOLID – Dependency Inversion Principle (DIP)

The **Dependency Inversion Principle (DIP)** states that:  
➡️ *High-level modules should not depend on low-level modules. Both should depend on abstractions.*  
➡️ *Abstractions should not depend on details. Details should depend on abstractions.*  

This encourages using **interfaces or abstract classes** so that code is flexible and loosely coupled.

---

## 🔹 Why DIP Matters
- Reduces **tight coupling** between classes  
- Makes code easier to **test** (e.g., by mocking dependencies)  
- Encourages **modular design**  
- Makes systems more flexible and adaptable to change  

---

## 🔹 Examples

❌ **Without DIP (high-level depends on low-level directly):**
```csharp
public class FileLogger
{
    public void Log(string message)
    {
        Console.WriteLine("File log: " + message);
    }
}

public class UserService
{
    private FileLogger _logger = new FileLogger();

    public void Register(string username)
    {
        // Business logic...
        _logger.Log("User registered: " + username);
    }
}
```

✔ **With DIP (high-level depends on abstraction):**
```csharp
public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("File log: " + message);
    }
}

public class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("DB log: " + message);
    }
}

public class UserService
{
    private readonly ILogger _logger;

    public UserService(ILogger logger)
    {
        _logger = logger;
    }

    public void Register(string username)
    {
        // Business logic...
        _logger.Log("User registered: " + username);
    }
}
```

---

## 🔹 How to Apply DIP
- Depend on **interfaces or abstractions**, not concrete classes  
- Use **dependency injection** (constructor, property, or method injection)  
- Keep high-level modules free from knowledge of low-level details  
- Swap implementations easily (e.g., `FileLogger` → `DatabaseLogger`)  

---

## 📝 Summary
The **Dependency Inversion Principle** makes systems **flexible, testable, and maintainable**.  
By depending on abstractions instead of details, you can change implementations without breaking high-level logic.  
