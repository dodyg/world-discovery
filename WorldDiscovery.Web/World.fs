module World

type Customer = 
    { First: string
      Last: string
      SSN: uint32
      AccountNumber: uint32; }


type Country =
    {
        Name : string
    }

type World =
    {
        Countries : List<Country>
    }

let x : World = {
    Countries = [ { Name = "Shit"}]
};

