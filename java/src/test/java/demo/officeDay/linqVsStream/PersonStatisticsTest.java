package demo.officeDay.linqVsStream;

import org.junit.jupiter.api.Test;

import java.util.Comparator;
import java.util.List;
import java.util.Map;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.*;

public class PersonStatisticsTest {

    public static final String RESOURCE_NAME = "list.txt";
    PersonStatistics personStatistics = new PersonStatistics(Thread.currentThread().getContextClassLoader().getResourceAsStream(RESOURCE_NAME));

    @Test
    public void oldestPersonByCountry(){
        Map<String, Optional<Person>> oldestPersonByCountry = personStatistics.oldestPersonByCountry();

        Optional<Person> brazilian = oldestPersonByCountry.get("Brazil");
        assertTrue(brazilian.isPresent());
        assertEquals("Shel", brazilian.get().getName());


        Optional<Person> german = oldestPersonByCountry.get("Germany");
        assertTrue(german.isPresent());
        assertEquals("Karalee", german.get().getName());
    }

    @Test
    public void comparingOldestPeopleByCountryYieldSameResult(){
        Map<String, List<Person>> oldestPeopleByCountryImperative = personStatistics.oldestPeopleByCountryImperative();
        Map<String, List<Person>> oldestPeopleByCountry = personStatistics.oldestPeopleByCountry();


        List<Person> braziliansImperative = oldestPeopleByCountryImperative.get("Brazil");
        assertEquals(65, braziliansImperative.size());

        List<Person> brazilians = oldestPeopleByCountry.get("Brazil");
        assertEquals(65, brazilians.size());


        braziliansImperative.sort(Comparator.comparing(Person::getName));
        brazilians.sort(Comparator.comparing(Person::getName));

        assertIterableEquals(braziliansImperative, brazilians);
    }
}
