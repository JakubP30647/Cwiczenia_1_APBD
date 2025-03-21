namespace Cwiczenia_1_APBD;

public class ContainerAppTools
{
    public static ContainerLiquid AddLiquidContainer(double loadMaxMass, double hight, double selfMass, double deep,
        bool isDangerous)
    {
        return new ContainerLiquid(loadMaxMass, hight, selfMass, deep, isDangerous);
    }
    
    public static ContainerGas AddGasContainer(double loadMaxMass, double hight, double selfMass, double pressure, double deep)
    {
        return new ContainerGas(loadMaxMass, hight, selfMass, deep, pressure );
    }
    
    public static ContainerFreezer AddFreezerContainer(double loadMaxMass, double hight, double selfMass, Products products, double deep, double temperature)
    {
        return new ContainerFreezer(loadMaxMass, hight, selfMass, deep, products, temperature );
    }
    
    
    
}