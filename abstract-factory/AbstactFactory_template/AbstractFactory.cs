// Abstract Products
public interface IButton
{
    void Render();
}

public interface ICheckbox
{
    void Check();
}

// Concrete Products
public class WinButton : IButton
{
    public void Render() => Console.WriteLine("Render a Windows-style button");
}

public class MacButton : IButton
{
    public void Render() => Console.WriteLine("Render a Mac-style button");
}

public class WinCheckbox : ICheckbox
{
    public void Check() => Console.WriteLine("Check a Windows-style checkbox");
}

public class MacCheckbox : ICheckbox
{
    public void Check() => Console.WriteLine("Check a Mac-style checkbox");
}

// Abstract Factory
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Factories
public class WinFactory : IGUIFactory
{
    public IButton CreateButton() => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

// Client
public class Application
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void RenderUI()
    {
        _button.Render();
        _checkbox.Check();
    }
}

// Program.cs
class AbstractFactory
{
    static void Main()
    {
        IGUIFactory factory = new WinFactory(); // або new MacFactory()
        Application app = new Application(factory);
        app.RenderUI();
    }
}
