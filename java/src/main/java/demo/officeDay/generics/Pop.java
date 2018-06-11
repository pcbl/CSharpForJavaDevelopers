package demo.officeDay.generics;

import demo.officeDay.getSet.Person;

import java.util.ArrayList;
import java.util.List;

public class Pop {

    public Pop(){
        this.fans = new ArrayList<>();
    }

    public Person getFirstFan(){
        return fans.get(0);
    }

    List<Person> fans;
}
