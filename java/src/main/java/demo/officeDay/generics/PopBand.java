package demo.officeDay.generics;

public class PopBand extends GenericBand<Pop> {
    @Override
    public Pop play() {
        return new Pop();
    }
}
