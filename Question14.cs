using System;

//Create a class 
public class TemperatureChangedEventArgs : EventArgs
{
    public double NewTemperature { get; }

    public TemperatureChangedEventArgs(double newTemperature)
    {
        NewTemperature = newTemperature;
    }
}

//  Set up the delegate 
public delegate void TemperatureChangedEventHandler(object sender, TemperatureChangedEventArgs e);

// Step 3: Declare the code for the event
public class TemperatureSensor
{
    // Event declaration
    public event TemperatureChangedEventHandler TemperatureChanged;

    private double currentTemperature;

    public TemperatureSensor(double initialTemperature)
    {
        currentTemperature = initialTemperature;
    }

   
    public void SimulateTemperatureChange(double newTemperature)
    {
        currentTemperature = newTemperature;
        OnTemperatureChanged(new TemperatureChangedEventArgs(newTemperature));
    }

    //  Create code that will be run when the event occurs (Event Handler)
    protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
    {
        TemperatureChanged?.Invoke(this, e);
    }
}

// Associate the event with the event handler
public class TemperatureDisplay
{
    public TemperatureDisplay(TemperatureSensor sensor)
    {
        sensor.TemperatureChanged += HandleTemperatureChanged;
    }

    // Event handler method
    private void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"Temperature changed: {e.NewTemperature} °C");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        TemperatureSensor sensor = new TemperatureSensor(25.0);

        
        TemperatureDisplay display = new TemperatureDisplay(sensor);

       
        sensor.SimulateTemperatureChange(28.5);
        sensor.SimulateTemperatureChange(26.8);
    }
}
