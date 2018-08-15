//PROJECT TITLE: Josephus
//VERSION or DATE: 12/10/2009
//AUTHORS: jhonny lopez

public class Josephus {
    public static void main(String[] args) {
        int M = Integer.parseInt(args[0]);
        int N = Integer.parseInt(args[1]);

            Queue q = new Queue();
            for (int i = 1; i <= N; i++)
                 q.enqueue(i);

     while (!q.isEmpty()) {
           for (int i = 0; i < M - 1; i++)
                q.enqueue(q.dequeue());
            System.out.print(q.dequeue() + " ");
        
         }
            System.out.println();
    }
}


