package demo.officeDay.generics;

public class RockBand extends GenericBand<Rock> {
    @Override
    public Rock play() {
        return new Rock();
    }
}
