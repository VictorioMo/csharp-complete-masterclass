# SOLID – Liskov Substitution Principle (LSP)

The **Liskov Substitution Principle (LSP)** states that:  
➡️ *Objects of a superclass should be replaceable with objects of its subclasses without breaking the application.*  

In other words, subclasses must behave in a way that doesn’t violate the expectations set by their base class.

---

## 🔹 Why LSP Matters
- Ensures **correct inheritance** without surprises  
- Keeps polymorphism safe and reliable  
- Makes code more predictable and easier to extend  
- Prevents subtle bugs caused by violating parent contracts  

---

## 🔹 Examples

❌ **Without LSP (subclass breaks behavior):**
```csharp
public class Bird
{
    public virtual void Fly() 
    {
        Console.WriteLine("Flying...");
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Penguins can’t fly!");
    }
}
```

➡️ Problem: A `Penguin` is a `Bird`, but it breaks the contract because it cannot actually fly.

✔ **With LSP (design respects substitution):**
```csharp
public abstract class Bird
{
    public abstract void Move();
}

public class Sparrow : Bird
{
    public override void Move()
    {
        Console.WriteLine("Flying...");
    }
}

public class Penguin : Bird
{
    public override void Move()
    {
        Console.WriteLine("Swimming...");
    }
}
```
---

## 🔹 How to Apply LSP
- Subclasses must **honor the behavior** of their base class  
- Avoid overriding methods in ways that break expected functionality  
- Use **abstractions** that reflect real-world differences (e.g., `Move` instead of `Fly`)  
- If a subclass cannot logically follow the parent contract, consider redesigning the hierarchy  

---

## 📝 Summary
The **Liskov Substitution Principle** ensures that inheritance models real-world behavior correctly.  
If a subclass cannot fully behave like its parent, it’s a sign the class hierarchy needs redesign.  
