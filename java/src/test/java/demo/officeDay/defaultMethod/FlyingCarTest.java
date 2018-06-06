package demo.officeDay.defaultMethod;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class FlyingCarTest {
    @Test
    public void defaultInfo(){
        FlyingCar flyingCar = new FlyingCar();
        assertEquals("This is to solve multiple inheritance method conflict", flyingCar.getMaker());
        assertEquals("Unknown Model", flyingCar.getModel());
        assertEquals(2000, flyingCar.getMaxAltitude());
        assertEquals(140, flyingCar.getMaxSpeed());
    }

}
