using System;
using CosmicCuration.Utilities;
using CosmicCuration.PowerUps;

public class PowerUpPool : GenericObjectPool<PowerUpController>
{
    private PowerUpData powerUpData;

    public PowerUpController GetPowerUp<T>(PowerUpData powerUpData) where T : PowerUpController
    {
        this.powerUpData = powerUpData;
        return GetItem<T>();
    }

    protected override PowerUpController CreateItem<T>()
    {
        if (typeof(T) == typeof(Shield))
            return new Shield(powerUpData);
        else if (typeof(T) == typeof(DoubleTurret))
            return new DoubleTurret(powerUpData);
        else if (typeof(T) == typeof(RapidFire))
            return new RapidFire(powerUpData);
        else
            throw new NotSupportedException($"PowerUp type not supported.");
    }
}