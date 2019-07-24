#include<iostream>
#include<conio.h>
using namespace std;
#define MAX 999 
#define TRUE 1 
#define FALSE  0 
int A[50][50];// mang de duyet 
int D[50][50];// mang chua do dai ngan nhat tu i->j
int p[50][50];// mang chua dinh giua i va j
int n;// so dinh
int u;// dinh dau
int v;// dinh cuoi
int _step = 0;
void Input(void){
	// freopen("prim_matrix_4.inp", "r", stdin);
	 freopen("input.IN", "r", stdin);
	 cin>>n;
	 cout<<"So dinh cua do thi: "<< n <<endl;
// khoi tao mang A
	for (int i = 1; i <= n; i++){
		for (int j = 1; j <= n; j++){
		    cin>>A[i][j];
		    if(A[i][j] == 0)
		    A[i][j] = MAX;
		}
	}
}
// in duong di tu v<-u
void ketqua(int u,int v){
	if (D[u][v] >= MAX) {
		cout<<"Khong co duong di";
	}
	 else {
	    cout<<"di tu "<<u<<" den "<<v<< " co do dai la "<<D[u][v]<<endl;
	    cout<<"Duong di: " << v;
		while (v != u) {
			 cout<<" <-- ";
		    if (p[u][v] != 0) {
		    	cout <<p[u][v];
			    v = p[u][v];
			}
		    else {
		    	cout << u;
		    	v = u;
			}
		}
	}
}
void step(){
	cout << "+K = " << _step <<endl;
	cout << "-D" <<_step <<endl;
	for(int a = 1; a <=n; a++){
			for(int b = 1; b <=n ;b++){
				cout << D[a][b];				
				if (D[a][b] < 10) cout << "   ";
				else if (D[a][b] < 100) cout << "  ";
				else cout << " ";
			}
			cout << endl;
		}
		cout << "-p"<<_step <<endl;
		for(int a = 1; a <=n; a++){			
			for(int b = 1; b <=n ;b++){
				cout << p[a][b];				
				if (p[a][b] < 10) cout << "   ";
				else if (p[a][b] < 100) cout << "  ";
			}
			cout << endl;
		}		
	_step++;
	cout <<endl;
}
void Floyd(){
	int i, j, k;
	// khoi tao mang p va D
	for (i = 1; i <= n; i++){			
		for (j = 1; j <= n; j++){
		    D[i][j] = A[i][j];
			p[i][j] = 0;
		}
    }
    step();
 // duyet tu dinh 1-> k
	 	for (k = 1; k <= n; k++){ 
		  	for (i = 1; i <= n; i++){
			  	if(D[i][k] > 0 && D[i][k] < MAX) // neu ton tai duong di tu i->k
			  	{			  	
				  	for (j = 1; j <= n; j++) {
				  		if (i == j) continue;
					  	if(D[k][j]>0&&D[k][j]<MAX) // neu ton tai duong di tu k->j
					    {
					  		if ( D[i][j] > (D[i][k] + D[k][j])) // neu duong ngan nhat di tu i->j> tong hai duong kia
							{				     
					     		D[i][j] = D[i][k] + D[k][j];
					     		p[i][j] = k;
							}				    
						}
			        }
		        }	
	        }
			step();
	   }
		
	}
int main(){
	 Input();
	 Floyd();
	 ketqua(1,3);
	 getch();
}

