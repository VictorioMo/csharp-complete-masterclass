# SOLID – Single Responsibility Principle (SRP)

The **Single Responsibility Principle (SRP)** states that:  
➡️ *A class should have only one reason to change.*  

In other words, each class or module should focus on **one responsibility** (or job).  
If a class takes on too many roles, it becomes harder to maintain, extend, and debug.

---

## 🔹 Why SRP Matters
- Easier to **understand** (small, focused classes)  
- Easier to **test** (fewer dependencies in each class)  
- Easier to **change** (updates affect only one responsibility)  
- Promotes **reuse** (small, independent classes can be reused elsewhere)  

---

## 🔹 Examples

❌ **Without SRP (one class doing too much):**
```csharp
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }

    // Business logic
    public void GenerateReport() { /* ... */ }

    // Saving logic
    public void SaveToFile(string filePath) { /* ... */ }

    // Printing logic
    public void PrintReport() { /* ... */ }
}
```

✔ **With SRP (split responsibilities):**
```csharp
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }

    public void GenerateReport() { /* ... */ }
}

public class ReportSaver
{
    public void SaveToFile(Report report, string filePath) { /* ... */ }
}

public class ReportPrinter
{
    public void PrintReport(Report report) { /* ... */ }
}
```

---

## 🔹 How to Apply SRP
- Ask: *“Does this class have more than one reason to change?”*  
- If yes → split it into multiple classes  
- Keep classes **small and focused**  
- Separate **business logic**, **data persistence**, and **presentation** concerns  

---

## 📝 Summary
The **Single Responsibility Principle** ensures that classes remain **clean, focused, and easy to maintain**.  
By giving each class *one job only*, you reduce complexity and improve code quality.  
