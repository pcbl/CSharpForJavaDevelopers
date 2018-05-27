package demo.officeDay.getSet;

public class Person {
    private final String initialized = "test";
    private final String constructorInitialized;

    public Person(){
        constructorInitialized = "test";
    }

    public String valuePublic;




    private String valueGetAndSet;

    public String getValueGetAndSet() {
        return valueGetAndSet;
    }

    public void setValueGetAndSet(String valueGetAndSet) {
        this.valueGetAndSet = valueGetAndSet;
    }



    private String valueGetAndPrivateSet;

    public String getValueGetAndPrivateSet() {
        return valueGetAndPrivateSet;
    }
}
