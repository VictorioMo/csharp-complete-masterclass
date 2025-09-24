# SOLID – Open/Closed Principle (OCP)

The **Open/Closed Principle (OCP)** states that:  
➡️ *Software entities should be open for extension, but closed for modification.*  

This means you should be able to **add new behavior** to a class without changing its existing code.  
Instead of editing a class directly, you extend it (e.g., via inheritance, interfaces, or composition).

---

## 🔹 Why OCP Matters
- Reduces the risk of introducing bugs when adding new features  
- Encourages building flexible, extendable systems  
- Keeps existing, tested code safe and stable  
- Supports scalable architectures  

---

## 🔹 Examples

❌ **Without OCP (modifying existing code for each new case):**
```csharp
public class Shape
{
    public string Type { get; set; }
}

public class AreaCalculator
{
    public double CalculateArea(Shape shape)
    {
        if (shape.Type == "Circle")
        {
            // ...
        }
        else if (shape.Type == "Square")
        {
            // ...
        }
        return 0;
    }
}
```

✔ **With OCP (extending behavior without modifying existing code):**
```csharp
public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public override double CalculateArea() => Math.PI * Radius * Radius;
}

public class Square : Shape
{
    public double Side { get; set; }
    public override double CalculateArea() => Side * Side;
}

public class AreaCalculator
{
    public double CalculateArea(Shape shape) => shape.CalculateArea();
}
```

---

## 🔹 How to Apply OCP
- Use **inheritance** and **polymorphism** to extend behavior  
- Use **interfaces** and **dependency injection** for flexibility  
- Avoid hardcoding conditions (like `if/else` or `switch` on types)  
- Protect tested classes from modification, but allow them to be extended  

---

## 📝 Summary
The **Open/Closed Principle** ensures your code is **safe to change and easy to extend**.  
Instead of constantly modifying old code, you add new functionality by extending existing structures.  
