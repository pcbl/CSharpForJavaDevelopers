package demo.officeDay.generics;

public class MusicService extends AbstractServiceCommunicator<Band, MusicStatistics> {

    @Override
    protected Class<MusicStatistics> getResponseClass() {
        return MusicStatistics.class;
    }
}
