import { useState } from 'react'

export const PostForm=()=>{
    const[name,setName] = useState('')
    const[from,setFrom] = useState('')
    const[to,setTo] = useState('')
    const[ammount,setAmmount] = useState('')
    const date = new Date();

    const submitHandler=(event)=>{
        event.preventDefault()
       fetch('https://localhost:5001/api/movedGoods/', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
        NomenclatureId: name,
        WarehouseFromId: from,
        WarehouseToId: to,
        Ammount: ammount,
        Date: date
        })
    })
    }
    return (
    <form onSubmit={submitHandler}>
        <div>
            <input
            type='text'
            placeholder='Id'
            value={name}
            onChange={(e) => setName(e.target.value)}
            />
        </div>
        <div>
        <input
            type='text'
            placeholder='Moved From'
            value={from}
            onChange={(e) => setFrom(e.target.value)}
            />
        </div>
        <div>
        <input
            type='text'
            placeholder='Moved To'
            value={to}
            onChange={(e) => setTo(e.target.value)}
            />
        </div>
        <div>
        <input
            type='text'
            placeholder='Ammount'
            value={ammount}
            onChange={(e) => setAmmount(e.target.value)}
            />
        </div>
        <button type='submit'>Submit New Movement</button>
    </form>
    )
}