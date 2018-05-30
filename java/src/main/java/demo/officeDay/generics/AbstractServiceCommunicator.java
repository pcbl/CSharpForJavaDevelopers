package demo.officeDay.generics;

import java.io.IOException;

public abstract class AbstractServiceCommunicator<IN, OUT> {

    public OUT communicate(IN input) throws IllegalAccessException, InstantiationException {
        System.out.println(getServiceByName(input));

        OUT response = getResponseClass().newInstance();
        System.out.println("RESPONSE: " + response.getClass().getName());

        return response;
    }

    private String getServiceByName(IN input) {
        return "GET /" + input.getClass().getSimpleName();
    }

    protected abstract Class<OUT> getResponseClass();
}
