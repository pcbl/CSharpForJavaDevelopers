package demo.officeDay.linqVsStream;

import java.io.InputStream;
import java.util.*;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class PersonStatistics {
    private List<Person> personList = new ArrayList<>();

    public Map<String, Optional<Person>> oldestPersonByCountry(){
        return personList.stream().collect(Collectors.groupingBy(Person::getCountry, Collectors.maxBy(Comparator.comparingInt(Person::getAge))));
    }

    public Map<String, List<Person>> oldestPeopleByCountryImperative() {
        Map<String, List<Person>> peopleByCountry = new HashMap<>();
        for(Person person : personList){
            List<Person> people = peopleByCountry.get(person.getCountry());

            if(people == null) {
                people = new ArrayList<>();
                people.add(person);
                peopleByCountry.put(person.getCountry(), people);
                continue;
            }

            Person personFromList = people.get(0);
            if(personFromList.getAge() < person.getAge()){
                people.clear();
                people.add(person);
            } else if(personFromList.getAge() == person.getAge()){
                people.add(person);
            }
        }
        return peopleByCountry;
    }


    public Map<String, List<Person>> oldestPeopleByCountryCustomCollector(){
        return personList.stream().collect(Collectors.groupingBy(Person::getCountry, Collector.of(
                () -> new ArrayList<>(),
                (people, person) -> {
                    if(people.isEmpty()) {
                        people.add(person);
                        return;
                    }
                    Person personFromList = people.get(0);
                    if(personFromList.getAge() < person.getAge()){
                        people.clear();
                        people.add(person);
                    } else if(personFromList.getAge() == person.getAge()){
                        people.add(person);
                    }
                },
                (people, people2) -> {
                    people.addAll(people2);
                    return people;
                }
        )));
    }

    public Map<String, List<Person>> oldestPeopleByCountry(){
        return personList.stream()
                .collect(Collectors.collectingAndThen(Collectors.groupingBy(Person::getCountry),
                    (peopleByCountry) -> {
                        peopleByCountry.forEach((country, people)-> {
                            int maxAge = people.stream()
                                    .mapToInt(Person::getAge)
                                    .max().getAsInt();

                            List<Person> oldestPeople = people.stream()
                                    .filter((person) -> person.getAge() == maxAge)
                                    .collect(Collectors.toList());

                            peopleByCountry.put(country, oldestPeople);
                        });
                        return peopleByCountry;
                    }));
    }

    public PersonStatistics(InputStream source){
        Scanner scanner = new Scanner(source);
        while(scanner.hasNext()){
            String[] lineTokens = scanner.nextLine().split(",");
            personList.add(new Person(lineTokens[0], lineTokens[1], Integer.valueOf(lineTokens[2])));
        }
        scanner.close();
    }

}
