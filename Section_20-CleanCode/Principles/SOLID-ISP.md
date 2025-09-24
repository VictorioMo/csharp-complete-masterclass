# SOLID – Interface Segregation Principle (ISP)

The **Interface Segregation Principle (ISP)** states that:  
➡️ *Clients should not be forced to depend on interfaces they do not use.*  

This means it’s better to have **many small, specific interfaces** rather than a single large, “fat” interface.

---

## 🔹 Why ISP Matters
- Prevents classes from being forced to implement unused methods  
- Makes code easier to **understand and maintain**  
- Encourages **modularity** and **separation of concerns**  
- Reduces risk of breaking code when modifying interfaces  

---

## 🔹 Examples

❌ **Without ISP (fat interface):**
```csharp
public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work() { /* works fine */ }
    public void Eat() 
    {
        throw new NotImplementedException("Robots don’t eat!");
    }
}
```

✔ **With ISP (smaller, focused interfaces):**
```csharp
public interface IWork
{
    void Work();
}

public interface IEat
{
    void Eat();
}

public class Human : IWork, IEat
{
    public void Work() { /* working */ }
    public void Eat() { /* eating */ }
}

public class Robot : IWork
{
    public void Work() { /* working */ }
}
```

---

## 🔹 How to Apply ISP
- Split large interfaces into **smaller, role-specific** ones  
- Ensure classes only implement the **methods they actually need**  
- Think in terms of **capabilities** (e.g., `IWork`, `IEat`, `IDrive`)  
- Keep contracts **clean and minimal**  

---

## 📝 Summary
The **Interface Segregation Principle** avoids “fat” interfaces and keeps code clean by ensuring classes only depend on what they truly need.  
Smaller, focused interfaces = cleaner, more flexible design.  
