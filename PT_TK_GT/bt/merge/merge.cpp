#include<stdio.h>
#include<iostream>
#include<conio.h>
/* tach cac phan tu cho den cuoi cung roi merge lai theo thu tu tang dan
 tach ben trai roi tach ben phai xong merge hai mang voi nhau theo thu tu tang dan
*/
 using namespace std;
 int A[50];
int n;
 //nhap mang


void Input(void){
	 freopen("input2.txt", "r", stdin);
	 cin>>n;
	 cout<<"So phan tu: "<< n <<endl;
// khoi tao mang A
	for (int i = 0; i < n; i++){
		    cin>>A[i];	
	}
}
 
// gop hai mang con arr[l...m] và arr[m+1..r]
void merge(int arr[], int l, int m, int r)
{ // l chi so left, r la right, m la middle
    int i, j, k; // i la chi so bat dau cua mang dau tien,j la mang thu hai
    int n1 = m - l + 1; // so pt mang ben trai
    int n2 =  r - m;// so pt mang ben pahi
 
    // tao cac mang tam
    int L[n1], R[n2];
 
    // coppy dl sang mang tam
    for (i = 0; i < n1; i++)
        L[i] = arr[l + i];
    for (j = 0; j < n2; j++)
        R[j] = arr[m + 1+ j];
 
    // gom hai mang tam vao mang arr
    i = 0; // khoi tao chi so bat dau cho mang dau tien
    j = 0; //khoi tao chi so bat dau cho mang thu hai 
    k = l; // khoi tao chi so bat dau cho mang luu ket qua
    while (i < n1 && j < n2)
    {
        if (L[i] <= R[j])
        {
            arr[k] = L[i];
            i++;
        }
        else
        {
            arr[k] = R[j];
            j++;
        }
        k++;
    }
 
    // coppy cac pt con lai cua mang R vao arr neu co
    while (i < n1)
    {
        arr[k] = L[i];
        i++;
        k++;
    }
 
    // coppy cac pt con lai cua mang R vao arr neu co 
    while (j < n2)
    {
        arr[k] = R[j];
        j++;
        k++;
    }
}
 
// l la chi so trai,r la phai cua mang can dc sap xep
void mergeSort(int arr[], int l, int r)
{
    if (l < r)
    {
        // Tuong tu (l+r)/2, nhung cách này tránh tràn so khi l và r lon
        int m = l+(r-l)/2;
 
        //goi de quy tiep tuc chia doi tung nua mang
        mergeSort(arr, l, m);
        mergeSort(arr, m+1, r); 
        merge(arr, l, m, r);
    }
}
 
 
// ham xuat mang
void printArray(int A[], int size)
{
    int i;
    for (i=0; i < size; i++)
        printf("%d ", A[i]);
    printf("\n");
}
 
 
int main()
{
   
 	Input();
    printf("Given array is \n");
    printArray(A,n);
 
    mergeSort(A, 0, n-1);
 
    printf("\nSorted array is \n");
    printArray(A, n);
    return 0;
}
 
