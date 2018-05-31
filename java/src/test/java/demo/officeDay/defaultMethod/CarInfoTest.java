package demo.officeDay.defaultMethod;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class CarInfoTest {
    @Test
    public void defaultStaticMethod(){
        CarInfo carInfo = CarInfo.create(300);
        assertEquals("Unknown Maker", carInfo.getMaker());
        assertEquals("Unknown Model", carInfo.getModel());
        assertEquals(300, carInfo.getMaxSpeed());
    }
}
