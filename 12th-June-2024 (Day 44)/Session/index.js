function checkingEvenNumbers(num)
{
    return num%2==0//boolean
}


function filteringEvenNumbers(numbers,callbackFunc)
{
    let numberArray=[]
    for(let value of numbers)
    {
        if(callbackFunc(value))
            numberArray.push(value)
    }
    return numberArray
}

let arrayOfNumbers=[22,45,99,3,8,44]
console.log(filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers))

function checkingEvenNumbers(num)
{
    return num%2==0//boolean
}


function filteringEvenNumbers(numbers,callbackFunc)
{
    let numberArray=[]
    for(let value of numbers)
    {
        if(callbackFunc(value))
            numberArray.push(value)
    }
    return ()=>console.log(numberArray)
}

let result=filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers)
result()

// reduce
let sumOfArrayElements=arrayOfNumbers.reduce((sum,value)=>{
return sum+value
})
console.log(sumOfArrayElements)

// foreach
arrayOfNumbers.forEach(num=>{console.log(num)})

//sort
arrayOfNumbers.sort((numOne,numTwo)=>numOne-numTwo)
console.log(arrayOfNumbers)
