package demo.officeDay.events;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Consumer;

public class Calculator {
    private int value = 0;
    private List<Consumer> listeners = new ArrayList<>();

    public void add(int toAdd){
        value += toAdd;
        listeners.forEach((listener) -> listener.accept(value));
    }

    public void addListener(Consumer listener){
        listeners.add(listener);
    }

    public void removeListener(Consumer listener){
        listeners.remove(listener);
    }
}
