import { Controller, Control } from "react-hook-form";
import Select, { StylesConfig } from "react-select";
import { SelectFieldOptionViewModel } from "../../../../models/Forms/SelectFieldOptionViewModel";
import "./SelectField.scss";

interface Props {
  control: Control<any>;
  name: string;
  errors: any;
  label: string;
  options: SelectFieldOptionViewModel[];
  placeholder?: string;
}

const customStyles: StylesConfig<SelectFieldOptionViewModel, false> = {
  control: (provided) => ({
    ...provided,
    height: "40",
    minHeight: "40",
    borderColor: "#ccc",
    boxShadow: "none",
    "&:hover": {
      borderColor: "#ccc",
    },
  }),
  valueContainer: (provided) => ({
    ...provided,
    padding: "0 0.75rem",
  }),
  singleValue: (provided) => ({
    ...provided,
    margin: "0",
    color: "inherit",
  }),
  input: (provided) => ({
    ...provided,
    margin: "0",
    padding: "0",
  }),
  indicatorSeparator: () => ({
    display: "none",
  }),
};

const SelectField = ({
  control,
  name,
  errors,
  label,
  options,
  placeholder,
}: Props) => {
  return (
    <div className="form-field">
      <label htmlFor={name}>{label}</label>
      <Controller
        name={name}
        control={control}
        render={({ field: { value, onChange } }) => {
          return (
            <Select
              options={options}
              placeholder={placeholder ? placeholder : ""}
              value={options.filter((option) => value?.includes(option.value))}
              onChange={(option) => onChange(option?.value)}
              styles={customStyles}
            />
          );
        }}
      />
      {errors[name] && (
        <div className="form-field-error">{errors[name].message}</div>
      )}
    </div>
  );
};

export default SelectField;
