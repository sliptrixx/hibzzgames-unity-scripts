### Hibzz.MoreColors
A class that provides a lot more colors by names based on HTML color names recognized by most browsers.

### Usage

```C#
using Hibzz.MoreColors;

class ExampleClass
{
    void ExampleFunction()
    {
        Color newColor = MoreColors.Tomato;
    }
}

```

### Generation Tool
The following c++ script was used to generate the content for this c# file

```c++
#include <iostream>
#include <string>
#include <vector>

std::vector<std::string> SplitWithCharacter(std::string str, int splitLength)
{
    int numString = str.length() / splitLength;
    std::vector<std::string> result;

    for(int i= 0; i < numString; i++)
    {
        result.push_back(str.substr(i*splitLength, splitLength));
    }

    if(str.length() % splitLength != 0)
    {
        result.push_back(str.substr(splitLength * numString));
    }

    return result;
}

struct COLOR
{
    int r;
    int g;
    int b;
};

COLOR HexToRGB(std::string hex)
{
    COLOR color;
    if(hex.at(0) == '#')
    {
        hex.erase(0, 1);
    }

    while(hex.length() < 6)
    {
        hex += "0";
    }

    std::vector<std::string> color_int = SplitWithCharacter(hex, 2);
    color.r = stoi(color_int[0], nullptr, 16);
    color.g = stoi(color_int[1], nullptr, 16);
    color.b = stoi(color_int[2], nullptr, 16);

    return color;    
}

// entry point
int main()
{
    std::string colorName;
    std::string colorHex;
    
    std::cout << "Enter name of the color: ";
    std::cin >> colorName;

    std::cout << "Enter hex value of the color: ";
    std::cin >> colorHex;

    COLOR color = HexToRGB(colorHex);
    float r = color.r / 255.0f;
    float g = color.g / 255.0f;
    float b = color.b / 255.0f;

    std::cout << "public static Color " << colorName << " { get { return new Color (" << r << "f, " << g << "f, " << b << "f); } }" << std::endl;
}
```
