import axios from 'axios'
import React from 'react'
import Image from 'next/image';

export default async function page({params}:any) {
    const res = await axios.get(`https://dummyjson.com/users/${params.player}`);
    console.log(res.data)
    return(
        <div className='playerCard'>
            <>
                <Image
                    src={res.data.image}
                    alt="player"
                    height={300}
                    width={300}
                />
            </>
            {res.data.firstName}
            {res.data.lastName}  
            {res.data.age}  
            {res.data.gender}  
            {res.data.phone}  
            {res.data.email}
        </div>
    )  
}