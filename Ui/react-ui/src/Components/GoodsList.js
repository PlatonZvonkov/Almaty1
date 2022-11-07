import { useState,useEffect } from 'react'
import './myStyles.css'

export const GoodsList=()=>{
    const [goods, setGoods] = useState([])

    useEffect(()=>{
        fetch('https://localhost:5001/api/movedGoods/10').then(
            response => response.json())
            .then(data=>setGoods(data))
            .catch(err=>{console.log(err)})
    },[])

    const deleteHandler=(event)=>{
        event.preventDefault()
       fetch('https://localhost:5001/api/movedGoods/', {
        method: 'DELETE',
        body: JSON.stringify({
            //TODO
  }),
     headers: {
    'Content-type': 'application/json; charset=UTF-8',
     },
    })
    .then((response) => response.json())
    .then((json) => console.log(json));
    }
    return <div>
        <div class="flex-container">
            <div ><h1>Moved Goods</h1></div>
            <div ><h1>Moved From</h1></div>
            <div ><h1>Moved To</h1></div>
            <div ><h1>Date</h1></div>
            <div ><h1>Ammount</h1></div>
        </div>
        <p>
        {
            goods.map(item=>{
                return <div key={item.date} class="flex-container">
                    <div>{item.nomenclatureName}</div>
                    <div>{item.warehouseFrom}</div>
                    <div>{item.warehouseTo}</div>
                    <div>{item.date}</div>
                    <div>{item.ammount}</div>
                    <div><button onClick={deleteHandler}>Delete</button></div>
                    </div>
            })
        }
        </p>
    </div>
}