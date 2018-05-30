package demo.officeDay.generics;

import demo.officeDay.linqVsStream.Person;

public class HealthService extends AbstractServiceCommunicator<Person, HealthInformation> {

    @Override
    protected Class<HealthInformation> getResponseClass() {
        return HealthInformation.class;
    }
}
