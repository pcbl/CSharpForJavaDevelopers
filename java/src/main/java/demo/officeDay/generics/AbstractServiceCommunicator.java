package demo.officeDay.generics;

import java.lang.reflect.ParameterizedType;

public abstract class AbstractServiceCommunicator<IN, OUT> {

    public OUT communicate(IN input) throws IllegalAccessException, InstantiationException, ClassNotFoundException {
        System.out.println(getServiceByName(input));

        OUT response = getResponseClass().newInstance();
        System.out.println("RESPONSE: " + response.getClass().getName());

        return response;
    }

    private String getServiceByName(IN input) {
        return "GET /" + input.getClass().getSimpleName();
    }

    protected abstract Class<OUT> getResponseClass();

    private Class<OUT> getResponseClassReflection() throws ClassNotFoundException {
        String genericResponseClassName = ((ParameterizedType) getClass().getGenericSuperclass()).getActualTypeArguments()[1].getTypeName();
        return (Class<OUT>) Thread.currentThread().getContextClassLoader().loadClass(genericResponseClassName);
    }
}
