import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;

public class SortModel {
    public enum SORT_METHOD {INSERTION, SELECTION, QUICK, MERGE};
    private int[] initialArray;
    private int[] array;
    private SORT_METHOD sortMethod;
    private PropertyChangeSupport changeSupport;

    public SortModel(int[] array) {
        this.array = array;
        this.sortMethod = SORT_METHOD.INSERTION;
        this.changeSupport = new PropertyChangeSupport(this);
        this.initialArray = new int[array.length];

        for (int i = 0; i < array.length; i++) {
            initialArray[i] = array[i];
        }
    }

    public SortModel(int[] array, SORT_METHOD method) {
        this.array = array;
        this.sortMethod = method;
        this.changeSupport = new PropertyChangeSupport(this);
        updateListeners();
    }

    public int[] getArray() {
        return array;
    }

    public void setArray(int[] array) {
        this.array = array;
        updateListeners();
    }

    public void setSortMethod(SORT_METHOD method) {
        changeSupport.firePropertyChange("method change", sortMethod, method);
        sortMethod = method;
    }

    public String getSortMethod() {
        return sortMethod.name();
    }

    public void reset() {
        array = initialArray;
        updateListeners();
    }

    public void sort() {
        switch (sortMethod) {
            case INSERTION:
                insertionSort();
                break;
            case QUICK:
                quickSort();
                break;
            default:
                break;
        }
    }

    public void insertionSort() {
        for (int i = 1; i < array.length; i++) {
            int currVal = array[i];
            int j = i - 1;

            while (j != -1 && array[j] > currVal) {
                delay(1);
                array[j + 1] = array[j];
                j--;
                updateListeners();
            }

            array[j + 1] = currVal;
        }
    }

    public void quickSort() {
        quickSortHelper(0, array.length - 1);
    }

    private void quickSortHelper(int start, int end) {
        if (start < end) {
            int pivot = partition(start, end);

            quickSortHelper(start, pivot - 1);
            quickSortHelper(pivot + 1, end);
        }
    }

    private int partition(int start, int end) {
        int pivot = array[end];
        int lowIndex = start; // The ending index of where the lower numbers are.

        for (int i = start; i < end; i++) {
            delay(1);
            if (array[i] <= pivot) {
                int tmp = array[i];
                array[i] = array[lowIndex];
                array[lowIndex] = tmp;

                lowIndex++;
                updateListeners();
            }
        }

        array[end] = array[lowIndex];
        array[lowIndex] = pivot;


        return lowIndex;
    }

    public void addPropertyChangeListener(PropertyChangeListener listener) {
        changeSupport.addPropertyChangeListener(listener);
    }

    public void removePropertyChangeListener(PropertyChangeListener listener) {
        changeSupport.removePropertyChangeListener(listener);
    }

    private void updateListeners() {
        changeSupport.firePropertyChange("array changed", null, array);
    }

    public PropertyChangeListener[] getPropertyChangeListeners() {
        return changeSupport.getPropertyChangeListeners();
    }

    private void delay(int ms) {
        try {
            Thread.sleep(ms);
        } catch (Exception e) {
            // Shouldn't get here.
        }
    }

    public String toString() {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < array.length; i++) {
            builder.append(array[i] + " ");
        }

        return builder.toString();
    }

}
