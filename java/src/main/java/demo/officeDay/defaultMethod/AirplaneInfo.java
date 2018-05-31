package demo.officeDay.defaultMethod;

public interface AirplaneInfo {

    String UNKNOWN_MAKER = "Unknown Maker";

    default String getMaker(){
        return UNKNOWN_MAKER;
    }

    int getMaxAltitude();

}
