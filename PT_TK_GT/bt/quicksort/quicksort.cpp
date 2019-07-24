#include<stdio.h>
#include<iostream>
#include<conio.h>
/*  sap xep cho ben trai nho hon pivot, ben phai lon hon pivot
 pivot la pt cuoi cung cua mang dang xet. tiep tuc chia nho cho den het
*/
 using namespace std;
int A[50];
int n;
int dem=0;
// ham xuat
void printArray(int arr[], int size)
{
    int i;
    for (i=0; i < size; i++)
        printf("%d ", arr[i]);
    printf("\n");
}
void swap(int &a, int &b)
{
    int t = a;
    a = b;
    b = t;
}
 
 
int partition (int arr[], int low, int high)
{
    int pivot = arr[high];    // pivot
    int left = low; // chi so dau
    int right = high - 1;// chi so cuoi
    while(true){
        while(left <= right && arr[left] <= pivot) left++;// so sanh pt left voi pilot neu nho hon thi tang i
        while(right >= left && arr[right] >= pivot) right--;//so sanh pt right voi pilot neu lon hon thi giam j
        if (left >= right) break;
        swap(arr[left], arr[right]);// doi hai pt cho nhau
        dem++;
        printf("Sorted array %d: \n",dem);
    	printArray(arr, n);
        left++;
        right--;
    }
    swap(arr[left], arr[high]);
     	dem++;
        printf("Sorted array %d: \n",dem);
    	printArray(arr, n);
    return left;
}
 
/// ham thuc hien giai thuat quicksort
void quickSort(int arr[], int low, int high)
{ // duyet theo chieu sau
    if (low < high)
    {// pi la chi so noi phan tu nay da dung dung vi tri va phan tu chia mang lam 2 mang con trai va phai
       
        int pi = partition(arr, low, high);
 		// goi de quy sap xep 2 mang con trai va phai
        quickSort(arr, low, pi - 1);
        quickSort(arr, pi + 1, high);
    }
}
 

 // ham nhap

void Input(void){
	 freopen("in1.txt", "r", stdin);
	 cin>>n;
	 cout<<"So phan tu: "<< n <<endl;
// khoi tao mang A
	for (int i = 0; i < n; i++){
		    cin>>A[i];	
	}
}
 
int main()
{
    
    Input();
    quickSort(A, 0, n-1);
    printf("Sorted array: \n");
    printArray(A, n);
    return 0;
}
 
