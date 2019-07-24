#include <iostream>
using namespace std;

#define MAX 1000
bool DEBUG = true;

string s1, s2;
int C[MAX + 1][MAX + 1], l1, l2;
char M[MAX + 1];
int maxLen = 0;                
bool common[MAX + 1][MAX + 1]; 


void lcs()
{
    l1 = s1.length(), l2 = s2.length();
    for (int i = 0; i <= l1; i++)
    {
        for (int j = 0; j <= l2; j++)
        {
            common[i][j] = false;

            if (i == 0 || j == 0)
            {
                C[i][j] = 0;
            }
            else if (s1[i - 1] == s2[j - 1])
            {
                C[i][j] = C[i - 1][j - 1] + 1;
                //maxLen = max(maxLen, C[i][j]);
                if (maxLen < C[i][j])
                {
                    maxLen = C[i][j];
                    common[i][j] = true;
                }
            }
            else
            {
                C[i][j] = 0;
            }
        }
    }
}

/* Truy vết liệt kê nghiệm */
void trace()
{
    for (int i = 0; i <= l1; i++)
    {
        for (int j = 0; j <= l2; j++)
        {
            if (common[i][j] == true)
            {
                cout << s1[i - 1];
            }
        }
    }
    cout << "\nmaxLen = " << maxLen << endl;
}

int main()
{
    s1 = "HOAHONG", s2 = "KHOAHOC";
    s1 = "OldSite:GeeksforGeeks.org", s2 = "NewSite:GeeksQuiz.com";

    lcs();
    trace();

    return 0;
}
