##Project Euler - 54 Poker Hands

This is a C# solution to [project 54 - Poker hands](https://projecteuler.net/problem=54). 

### To run
The application can run in a docker container based on offical .Net Core image.

1: enter the source code directory

    cd c:\workspace\Project_euler_problems\54\CSharp
    
2: build the image

    docker build -t problem54 .

3: run tests
   
    docker run -it -v $(pwd):/src --rm  problem54

4: run

    docker run -it -v $(pwd):/src --rm  problem54 sh run.sh
    
5: 
    docker run -it -v $(pwd):/src --rm  problem54 /bin/bash
