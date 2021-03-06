package demo.officeDay.generics;

import demo.officeDay.linqVsStream.Person;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertNotNull;

public class GenericsTest {
    @Test
    public void javaGenericsLimitation() throws InstantiationException, IllegalAccessException, ClassNotFoundException {
        Band band = new Band();
        MusicStatistics musicStatistics = new MusicService().communicate(band);
        assertNotNull(musicStatistics);

        Person me = new Person("Kurimin", "Brazil", 30);
        HealthInformation healthInformation = new HealthService().communicate(me);
        assertNotNull(healthInformation);
    }

    @Test
    public void trueGenericMethod(){
        print(new Band());
        print(new Person("Babaca", "Brazil", 25));

        playMusic(new RockBand());
        playMusic(new PopBand());
    }

    public <T> void print(T target){
        System.out.println(target.getClass().getName());
    }

    public void playMusic(GenericBand band){
        Object genre = band.play();
        print(genre);
    }
}
