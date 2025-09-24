# Clean Code – Exception Handling

Exceptions are a powerful mechanism in C# to deal with unexpected situations.  
Good exception handling improves program stability and helps users (and developers) understand what went wrong.

---

## 🔹 When to Use Exceptions
- For **unexpected conditions** your program cannot handle normally  
- When input or state is **invalid** and execution cannot safely continue  
- To signal **serious errors** (e.g., failed network requests, missing files, invalid data parsing)  
- To provide **clear feedback** to the user or developer  

---

## 🔹 Best Practices
- Catch **specific exceptions** instead of using `catch (Exception ex)` everywhere  
- Use **multiple catch blocks** to handle different problems differently  
- Keep the **error messages informative**, not generic  
- Don’t use exceptions for **normal control flow** (e.g., checking if a list is empty)  
- Log exceptions for debugging and troubleshooting  

---

## 🔹 Examples

❌ **Bad practice (catching everything the same way):**
```csharp
try
{
    var number = int.Parse("abc");
    var file = File.ReadAllText("missing.txt");
}
catch (Exception ex)
{
    Console.WriteLine("Something went wrong.");
}
```

✔ **Good practice (handle errors specifically):**
```csharp
try
{
    var number = int.Parse("abc");
    var file = File.ReadAllText("missing.txt");
}
catch (FormatException ex)
{
    Console.WriteLine("Invalid number format: " + ex.Message);
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("File not found: " + ex.FileName);
}
catch (Exception ex)
{
    Console.WriteLine("Unexpected error: " + ex.Message);
}
```
## 🔹 How to Apply Exception Handling
- Wrap **risky code** (file access, network calls, parsing, database queries) in try/catch blocks  
- Provide **user-friendly error messages** instead of raw stack traces  
- Differentiate between **recoverable errors** (e.g., invalid input) and **fatal errors** (e.g., missing system resources)  
- Test exception scenarios to make sure they’re handled gracefully  

---

## 📝 Summary
Exception handling makes your application more **robust and user-friendly**.  
By catching specific exceptions and explaining what went wrong, you improve both **user experience** and **maintainability** of your code.  
