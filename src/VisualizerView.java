import javax.swing.*;
import java.awt.*;
import java.awt.image.BufferedImage;


public class VisualizerView extends JPanel {
    private int[] arrayToDraw;
    private int width, height;
    private BufferedImage arrayImage;
    private JLabel imageLabel;

    public VisualizerView(int width, int height) {
        this.arrayImage = new BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);
        this.imageLabel = new JLabel(new ImageIcon(arrayImage));
        this.arrayToDraw = new int[1];
        this.width = width;
        this.height = height;

        this.setPreferredSize(new Dimension(width, height));
        this.add(imageLabel);
    }

    public void clear() {
        Graphics g = arrayImage.getGraphics();
        g.setColor(Color.GRAY);
        g.drawRect(0, 0, width, height);
        g.dispose();
    }

    public void drawArray() {
        clear();

        Graphics g = arrayImage.getGraphics();

        int barWidth = Math.max(width / arrayToDraw.length, 1);

        // Draw array in bar graph format.
        for (int i = 0; i < arrayToDraw.length; i++) {
            int val = arrayToDraw[i];

            Color c;
            // Assuming val is in the range of 0 - 510
            if (val <= 255) { // Red for <= 255
                c = new Color(Math.abs(val - 255), 0, 0);
            } else { // Green for > 255
                c = new Color(0, val - 255, 0);
            }

            g.setColor(c);

            // Using Math.max and min here in the event that val is greater than the height.
            g.drawRect(i * barWidth, Math.max(height - val, 0), barWidth, Math.min(val, height));
        }

        g.dispose();
    }

}
