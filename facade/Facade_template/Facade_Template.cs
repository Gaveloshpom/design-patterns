// Підсистеми
class Subsystem1 {
    public void Method1() {
        Console.WriteLine("Subsystem1: Method1 executed.");
    }
}

class Subsystem2 {
    public void Method2() {
        Console.WriteLine("Subsystem2: Method2 executed.");
    }
}

// Facade
class Facade {
    private Subsystem1 _subsystem1 = new Subsystem1();
    private Subsystem2 _subsystem2 = new Subsystem2();

    public void OperationA() {
        _subsystem1.Method1();
    }

    public void OperationB() {
        _subsystem2.Method2();
    }

    public void OperationC() {
        _subsystem1.Method1();
        _subsystem2.Method2();
    }
}

// Клієнт
class Facade_Template {
    static void Main() {
        Facade facade = new Facade();
        facade.OperationA();
        facade.OperationB();
        facade.OperationC();
    }
}
