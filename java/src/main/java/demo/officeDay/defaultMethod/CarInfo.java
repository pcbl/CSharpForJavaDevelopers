package demo.officeDay.defaultMethod;

public interface CarInfo {

    String UNKNOWN_MAKER = "Unknown Maker";
    String UNKNOWN_MODEL = "Unknown Model";

    default String getMaker(){
        return UNKNOWN_MAKER;
    }

    default String getModel(){
        return UNKNOWN_MODEL;
    }

    int getMaxSpeed();

    static CarInfo create(int maxSpeed){
        return () -> maxSpeed;
    }
}
