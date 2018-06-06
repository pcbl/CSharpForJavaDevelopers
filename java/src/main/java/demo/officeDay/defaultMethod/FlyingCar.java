package demo.officeDay.defaultMethod;

public class FlyingCar implements CarInfo, AirplaneInfo {

    @Override
    public String getMaker() {
        return "This is to solve multiple inheritance method conflict";
    }

    @Override
    public int getMaxSpeed() {
        return 140;
    }

    @Override
    public int getMaxAltitude() {
        return 2000;
    }
}
