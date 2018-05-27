package demo.officeDay.events;

import org.junit.jupiter.api.Test;

import java.util.function.Consumer;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class CalculatorTest {
    int currentValue = 0;

    @Test
    public void addTest(){
        Calculator calculator = new Calculator();

        int expectedValue = 3;

        Consumer<Integer> myHandler = (value) -> currentValue = value;
        calculator.addListener(myHandler);
        calculator.add(1);
        calculator.add(2);

        calculator.removeListener(myHandler);

        calculator.add(5);

        assertEquals(expectedValue, currentValue);
    }
}
