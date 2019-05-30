import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;
import java.util.ArrayList;

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

    public void bucketSort() {
        int maxValue = findMax() + 1;

        ArrayList<ArrayList<Integer>> bucketList = new ArrayList<>(maxValue);

        for (int i = 0; i < maxValue; i++) {
            bucketList.add(new ArrayList<>());
        }

        for (int i = 0; i < array.length; i++) {
            bucketList.get(array[i]).add(array[i]);
        }

        int arrayIndex = 0; // Index of next array cell to fill.

        for (int i = 0; i < bucketList.size(); i++) {
            //bucketList.get(i).sort(Integer::compareTo); // O(nlogn).

            for (int j = 0; j < bucketList.get(i).size(); j++) {
                array[arrayIndex++] = bucketList.get(i).get(j);
            }
        }
    }

    public void countingSort() {
        int maxValue = findMax() + 1;

       int[] countArray = new int[maxValue];
       int[] indexArray = new int[maxValue];

       // Fill count array. Index represents value in array, value at index represents count of that index in array.
       for (int i = 0; i < array.length; i++) {
           countArray[array[i]]++;
       }

       // Fill index array.
       indexArray[0] = countArray[0];
       for (int i = 1; i < countArray.length; i++) {
           // Value at each index is equal to the value before it plus the number of times index appears in the array.
           indexArray[i] = countArray[i] + indexArray[i - 1];
       }

       // For every index, the value there is the number of times index must be added to the array.
       for (int i = 0; i < countArray.length; i++) {
           while (countArray[i] != 0) {
               /*
                After adding the index to the array, we decrement the count and also the index at which it gets
                placed again.
               */
               array[indexArray[i]-- - 1] = i;

               countArray[i]--;
           }
       }
    }

    private int findMax() {
       int maxSoFar = array[0];

       for (int i = 1; i < array.length; i++) {
           if (array[i] > maxSoFar) {
               maxSoFar = array[i];
           }
       }

       return maxSoFar;
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

    public static void main(String[] args) {
        int[] array = new int[1000];
        for (int i = 0; i < 1000; i++) {
            array[i] = (int) (Math.random() * 1000);
        }
        SortModel model = new SortModel(array);

        for (int i = 0; i < 1000; i++) {
            System.out.print(array[i] + " ");
        }

        System.out.println();

        model.bucketSort();

        for (int i = 0; i < 1000; i++) {
            System.out.print(array[i] + " ");

        }

        System.out.println();

        int[] arr2 = {5, 3, 3, 2, 1, 1, 4, 4, 3};

        SortModel model2 = new SortModel(arr2);

        model2.countingSort();

        for (int i = 0; i < arr2.length; i++) {
            System.out.print(model2.getArray()[i] + " ");
        }

        System.out.println();
    }
}
