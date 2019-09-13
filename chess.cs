using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chess : MonoBehaviour  {
	private int [,] board = new int[3,3];
	private int turn = 1;
	private int steps = 9;  //可以走多少步
	
	void start() {
		restart();
	}
	
	void restart() {
		steps = 9;
		turn = 1;
		for(int i = 0; i < 3; i++) {
			for(int j = 0; j < 3; j++) {
				board[i,j] = 0;
			}
		}
	}

    int check() { 
        //列举所有可能赢的状态
        int tmp = board[1,1];
        if(tmp != 0) {
            if(tmp == board[0, 0] && tmp == board[2, 2]) {
                return tmp;
            }
            if(tmp == board[0, 2] && tmp == board[2, 0]) {
               return tmp; 
            }
            if(tmp == board[0, 1] && tmp == board[2, 1]) {
               return tmp; 
            }
            if(tmp == board[1, 0] && tmp == board[1, 2]) {
               return tmp; 
            }
        }
        
        tmp = board[0,0];
        if(tmp != 0) {
            if(tmp == board[0,1] && tmp == board[0,2]) {
                return tmp;
            }
            if(tmp == board[1,0] && tmp == board[2,0]) {
                return tmp;
            }
        }
        
        tmp = board[2,2]; 
        if(tmp != 0) {
            if(tmp == board[2,0] && tmp == board[2,1]) {
                return tmp;
            }
            if(tmp == board[0,2] && tmp == board[1,2]) {
                return tmp;
            }
        }
        
        //打成平局
        if(steps == 0) {
            return 3;
        }
        else {
            return 0;
        }
    }

	private void OnGUI() {
		if(GUI.Button(new Rect(350,380,100,60), "Restart")) {
            restart();
        }
        
        int result = check();
        if(result == 1) {
            GUI.Label(new Rect(350, 20, 100, 50), "X wins");
        }
        else if(result == 2) {
            GUI.Label(new Rect(350, 20, 100, 50), "O wins");
        }
        else if(result == 3) {
            GUI.Label(new Rect(350, 20, 100, 50), "Tied");
        }

        for(int i = 0; i < 3; i++) {
            for(int j = 0; j < 3; j++) {
                //1代表×，2代表o
                if(board[i,j] == 1) {
                    GUI.Button(new Rect(i * 100 + 250, j * 100 + 60, 100, 100), "X");
                }
                if(board[i,j] == 2) {
                    GUI.Button(new Rect(i * 100 + 250, j * 100 + 60, 100, 100), "O");
                }
                if(GUI.Button(new Rect(i * 100 + 250, j * 100 + 60, 100, 100), "")) {
                     //开始的时候都是0
                    if(result == 0) {
                		if(turn == 1)  board[i,j] = 1;
						if(turn == 2)  board[i,j] = 2;
                        steps--;
                        if(steps % 2 == 1) {
                            turn = 1;
                        }
                        else turn = 2;
            		}
                }
            }  
        }
	}
}
