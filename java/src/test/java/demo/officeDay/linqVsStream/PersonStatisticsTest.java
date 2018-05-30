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
    public void performanceOldestPeopleByCountry1(){
        personStatistics.oldestPeopleByCountry();
    }

    @Test
    public void performanceOldestPeopleByCountry2(){
        personStatistics.oldestPeopleByCountry2();
    }

    @Test
    public void performanceOldestPeopleByCountry3(){
        personStatistics.oldestPeopleByCountry3();
    }

    @Test
    public void performanceOldestPeopleByCountry11(){
        personStatistics.oldestPeopleByCountry();
    }

    @Test
    public void performanceOldestPeopleByCountry21(){
        personStatistics.oldestPeopleByCountry2();
    }

    @Test
    public void performanceOldestPeopleByCountry31(){
        personStatistics.oldestPeopleByCountry3();
    }

    @Test
    public void comparingOldestPeopleByCountryYieldSameResult(){
        Map<String, List<Person>> oldestPeopleByCountry = personStatistics.oldestPeopleByCountry();
        Map<String, List<Person>> oldestPeopleByCountry2 = personStatistics.oldestPeopleByCountry2();
        Map<String, List<Person>> oldestPeopleByCountry3 = personStatistics.oldestPeopleByCountry3();


        List<Person> brazilians = oldestPeopleByCountry.get("Brazil");
        assertEquals(65, brazilians.size());

        List<Person> brazilians2 = oldestPeopleByCountry2.get("Brazil");
        assertEquals(65, brazilians2.size());

        List<Person> brazilians3 = oldestPeopleByCountry3.get("Brazil");
        assertEquals(65, brazilians3.size());


        brazilians.sort(Comparator.comparing(Person::getName));
        brazilians2.sort(Comparator.comparing(Person::getName));
        brazilians3.sort(Comparator.comparing(Person::getName));

        assertIterableEquals(brazilians, brazilians2);
        assertIterableEquals(brazilians2, brazilians3);
    }
}
